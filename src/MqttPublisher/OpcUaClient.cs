using Microsoft.Extensions.Logging;
using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Configuration;

namespace MqttPublisher;

public class OpcUaClient(ILogger<OpcUaClient> logger)
{
    private readonly object _lock = new();
    private ApplicationConfiguration _configuration;
    private SessionReconnectHandler _reconnectHandler;
    private ISession _session;
    private UAClientSettings _settings;

    public ISession Session => _session;
    public IUserIdentity UserIdentity { get; set; } = new UserIdentity();
    public int ReconnectPeriod { get; set; } = 5000;
    public int ReconnectPeriodExponentialBackoff { get; set; } = 15000;

    public async Task Run(UAClientSettings settings, IEnumerable<SubscribedValue> values)
    {
        _settings = settings;
        try
        {
            _configuration = new ApplicationConfiguration()
            {
                ApplicationName = "OpcUa.Publisher.Client",
                ApplicationUri = Utils.Format(@"urn:{0}:KCF.OpcUaServer", System.Net.Dns.GetHostName()),
                ApplicationType = ApplicationType.Client,
                SecurityConfiguration = new SecurityConfiguration
                {
                    ApplicationCertificate = new CertificateIdentifier { StoreType = @"Directory", StorePath = @"%CommonApplicationData%/OPC Foundation/CertificateStores/MachineDefault", SubjectName = "KCF.OpcUaClient" },
                    TrustedIssuerCertificates = new CertificateTrustList { StoreType = @"Directory", StorePath = @"%CommonApplicationData%/OPC Foundation/CertificateStores/UA Certificate Authorities" },
                    TrustedPeerCertificates = new CertificateTrustList { StoreType = @"Directory", StorePath = @"%CommonApplicationData%/OPC Foundation/CertificateStores/UA Applications" },
                    RejectedCertificateStore = new CertificateTrustList { StoreType = @"Directory", StorePath = @"%CommonApplicationData%/OPC Foundation/CertificateStores/RejectedCertificates" },
                    AutoAcceptUntrustedCertificates = true
                },
                TransportConfigurations = new TransportConfigurationCollection(),
                TransportQuotas = new TransportQuotas { OperationTimeout = 15000 },
                ClientConfiguration = new ClientConfiguration { DefaultSessionTimeout = 60000 },
                TraceConfiguration = new TraceConfiguration()
            };
            await _configuration.Validate(ApplicationType.Client);
            if (_configuration.SecurityConfiguration.AutoAcceptUntrustedCertificates)
            {
                _configuration.CertificateValidator.CertificateValidation += (s, e) => { e.Accept = e.Error.StatusCode == StatusCodes.BadCertificateUntrusted; };
            }

            var application = new ApplicationInstance
            {
                ApplicationName = "PubSub",
                ApplicationType = ApplicationType.Client,
                ApplicationConfiguration = _configuration
            };

            bool connected = await ConnectAsync(values).ConfigureAwait(false);

            if (connected)
            {
                logger.LogInformation("Connected!");
                ReconnectPeriod = 1000;
                ReconnectPeriodExponentialBackoff = 10000;
                Session.MinPublishRequestCount = 3;
                Session.TransferSubscriptionsOnReconnect = true;
            }
            else
            {
                logger.LogInformation("Could not connect to server!");
            }
        }
        catch (Exception e)
        {
            logger.LogError($"Unexpected Exception [{e.GetType().Name}] {e.Message}");
        }
    }

    public async Task<bool> ConnectAsync(IEnumerable<SubscribedValue> values)
    {
        try
        {
            if (_session != null && _session.Connected == true)
                logger.LogInformation("Session already connected!");
            else
            {
                ITransportWaitingConnection connection = null;
                logger.LogInformation($"Connecting to {_settings.ServerUrl}");
                var endpointDescription = CoreClientUtils.SelectEndpoint(_configuration, _settings.ServerUrl, !_settings.NoSecurity);

                var endpointConfiguration = EndpointConfiguration.Create(_configuration);
                var endpoint = new ConfiguredEndpoint(null, endpointDescription, endpointConfiguration);
                var sessionFactory = TraceableSessionFactory.Instance;

                var session = await sessionFactory.CreateAsync(
                    _configuration,
                    connection,
                    endpoint,
                    connection == null,
                    false,
                    _configuration.ApplicationName,
                    _settings.SessionLifeTime,
                    UserIdentity,
                    null,
                    _settings.CancellationToken
                ).ConfigureAwait(false);

                if (session != null && session.Connected)
                {
                    _session = session;
                    _session.KeepAliveInterval = _settings.KeepAliveInterval;
                    _session.DeleteSubscriptionsOnClose = false;
                    _session.TransferSubscriptionsOnReconnect = true;
                    _session.KeepAlive += Session_KeepAlive;
                    _reconnectHandler = new SessionReconnectHandler(true, ReconnectPeriodExponentialBackoff);

                    // Define subscription parameters
                    Subscription subscription = new(session.DefaultSubscription)
                    {
                        DisplayName = "OpcUaClient subscription",
                        PublishingEnabled = true,
                        PublishingInterval = 1000,
                        LifetimeCount = 0,
                        MinLifetimeInterval = 6000,
                    };
                    session.AddSubscription(subscription);

                    // Create the subscription on Server side
                    subscription.Create();
                    logger.LogInformation($"New Subscription created with SubscriptionId = {subscription.Id}");

                    foreach (var value in values)
                    {
                        MonitoredItem monitoredItem = value.CreateItem(subscription);
                        monitoredItem.Notification += OnMonitoredItemNotification;
                        subscription.AddItem(monitoredItem);
                        var propertyItems = value.CreatePropertyItems(subscription);
                        foreach (var propertyItem in propertyItems)
                        {
                            propertyItem.Notification += OnMonitoredItemNotification;
                            subscription.AddItem(propertyItem);
                        }
                    }

                    subscription.ApplyChanges();
                }

                logger.LogInformation($"New Session Created with SessionName = {_session?.SessionName}");
            }

            return true;
        }
        catch (Exception ex)
        {
            logger.LogError($"Create Session Error : {ex.Message}");
            return false;
        }
    }

    public void Disconnect()
    {
        try
        {
            if (_session != null)
            {
                logger.LogInformation("Disconnecting...");
                lock (_lock)
                {
                    _session.KeepAlive -= Session_KeepAlive;
                    _reconnectHandler?.Dispose();
                    _reconnectHandler = null;
                }
                _session.Close();
                _session.Dispose();
                _session = null;
                logger.LogInformation("Session Disconnected.");
            }
            else
            {
                logger.LogInformation("Session not created!");
            }
        }
        catch (Exception ex)
        {
            logger.LogInformation($"Disconnect Error : {ex.Message}");
        }
    }

    // Handle DataChange notifications from Server
    private void OnMonitoredItemNotification(MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs e)
    {
        try
        {
            var value = monitoredItem.Handle as SubscribedValue;
            lock (value.Lock)
            {
                MonitoredItemNotification notification = e.NotificationValue as MonitoredItemNotification;

                value.Value = notification.Value.WrappedValue;
                value.Timestamp = notification.Value.ServerTimestamp;
                value.StatusCode = (uint)notification.Value.StatusCode;
                value.IsDirty = true;
            }
            logger.LogInformation($"==> {value.Name}, {value.NodeId}: value.Value: {value.Value}");
        }
        catch (Exception ex)
        {
            logger.LogInformation($"OnMonitoredItemNotification error: {ex.Message}");
        }
    }

    // Handles a keep alive event from a session and triggers a reconnect if necessary.
    private void Session_KeepAlive(ISession session, KeepAliveEventArgs e)
    {
        try
        {
            if (ServiceResult.IsBad(e.Status))
            {
                if (ReconnectPeriod <= 0)
                {
                    logger.LogInformation($"KeepAlive status {e.Status}, but reconnect is disabled.");
                    return;
                }

                if (_session != null)
                {
                    foreach (var subscription in _session.Subscriptions)
                    {
                        foreach (var monitoredItem in subscription.MonitoredItems)
                        {
                            var value = monitoredItem.Handle as SubscribedValue;
                            lock (value.Lock)
                            {
                                value.Value = Variant.Null;
                                value.Timestamp = DateTime.UtcNow;
                                value.StatusCode = StatusCodes.BadNotConnected;
                                value.IsDirty = true;
                            }
                        }
                    }
                }

                if (_session != null && _reconnectHandler != null)
                {
                    var state = _reconnectHandler.BeginReconnect(_session, null, ReconnectPeriod, Client_ReconnectComplete);
                    if (state == SessionReconnectHandler.ReconnectState.Triggered)
                        logger.LogInformation($"KeepAlive status {e.Status}, reconnect status {state}, reconnect period {ReconnectPeriod}ms.");
                    else
                        logger.LogInformation($"KeepAlive status {e.Status}, reconnect status {state}.", e.Status, state);
                }

                return;
            }
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Error in OnKeepAlive.");
        }
    }

    // Called when the reconnect attempt was successful.
    private void Client_ReconnectComplete(object sender, EventArgs e)
    {
        // ignore callbacks from discarded objects.
        if (!ReferenceEquals(sender, _reconnectHandler))
            return;

        lock (_lock)
        {
            if (_reconnectHandler?.Session != null)
            {
                if (!ReferenceEquals(_session, _reconnectHandler.Session))
                {
                    logger.LogInformation($"Reconnect to new session {_reconnectHandler.Session.SessionId}");
                    var session = _session;
                    _session = _reconnectHandler.Session;
                    Utils.SilentDispose(session);
                }
                else
                    logger.LogInformation($"Reactivate session {_reconnectHandler.Session.SessionId}");
            }
            else
                logger.LogInformation("Reconnect KeepAlive recovered");
        }
    }
}

public class UAClientSettings
{
    public bool RenewCertificate { get; set; } = false;
    public int KeepAliveInterval { get; set; } = 5000;
    public uint SessionLifeTime { get; set; } = 60 * 1000;
    public bool AutoAccept { get; set; } = false;
    public string LogFile { get; set; }
    public bool NoSecurity { get; set; } = false;
    public string UserName { get; set; }
    public string Password { get; set; }
    public string ServerUrl { get; set; } = "opc.tcp://localhost:62541/";
    public CancellationToken CancellationToken { get; set; } = default;
    public TextWriter OutputWriter { get; set; } = Console.Out;
}

public class SubscribedValue
{
    public SubscribedValue(object @lock)
    {
        Lock = @lock ?? new object();
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public string NodeId { get; set; }
    public Variant Value { get; set; }
    public DateTime Timestamp { get; set; }
    public uint StatusCode { get; set; }
    public bool IsDirty { get; set; } = false;
    public List<SubscribedValue> Properties { get; set; }
    public object Lock { get; set; }

    public MonitoredItem CreateItem(Subscription subscription)
    {
        if (subscription == null) throw new ArgumentNullException(nameof(subscription));

        lock (Lock)
        {
            MonitoredItem monitoredItem = new(subscription.DefaultItem)
            {
                StartNodeId = ExpandedNodeId.Parse(NodeId, subscription.Session.NamespaceUris),
                AttributeId = Attributes.Value,
                DisplayName = Name,
                SamplingInterval = 1000,
                QueueSize = 0,
                DiscardOldest = true,
                Handle = this
            };

            return monitoredItem;
        }
    }

    public List<MonitoredItem> CreatePropertyItems(Subscription subscription)
    {
        if (subscription == null) throw new ArgumentNullException(nameof(subscription));

        lock (Lock)
        {
            List<MonitoredItem> items = new();

            if (Properties?.Count > 0)
            {
                foreach (var property in Properties)
                {
                    MonitoredItem monitoredItem = new(subscription.DefaultItem)
                    {
                        StartNodeId = ExpandedNodeId.Parse(property.NodeId, subscription.Session.NamespaceUris),
                        AttributeId = Attributes.Value,
                        DisplayName = property.Name,
                        SamplingInterval = 1000,
                        QueueSize = 0,
                        DiscardOldest = true,
                        Handle = property
                    };

                    items.Add(monitoredItem);
                }
            }

            return items;
        }
    }
}
