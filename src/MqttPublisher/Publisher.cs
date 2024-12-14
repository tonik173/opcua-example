using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Domain;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Formatter;
using Opc.Ua;
using MqttCommon;
using Microsoft.Extensions.Logging;

namespace MqttPublisher;

public class Publisher(ILogger<Publisher> logger, OpcUaClient opcUaClient)
{
    const string _publisherId = "DemoPublisher";
    const string _groupName = "Progress";
    const string _writerName = "HarnessMachine";
    const string _dataSetName = "ProgressMetrics";
    const int _dataSetWriterId = 101;
    const string _opcUaServerUrl = "opc.tcp://localhost:62541/HarnessMachine/OpcUaServer";
    string NORMAL = "\x1b[39m";
    string RED = "\x1b[91m";

    const int PublishingInterval = 5000;
    const int MetaDataPublishingCount = 10;
    const int KeepAliveCount = 3;
    const int KeyFrameCount = 12;

    private MqttFactory _mqttFactory;
    private IMqttClient _mqttClient;
    private readonly object _lock = new();
    private Dictionary<string, SubscribedValue> _observers;
    private uint _metadataVersion;
    private readonly HashSet<string> _retainedTopics = new();

    private IServiceMessageContext MessageContext => opcUaClient?.Session?.MessageContext ?? ServiceMessageContext.GlobalContext;

    public async Task Connect()
    {
        _mqttFactory = new MqttFactory();

        using (_mqttClient = _mqttFactory.CreateMqttClient())
        {
            var willTopic = new Topic()
            {
                TopicPrefix = Config.TopicPrefix,
                MessageType = MessageTypes.Status,
                PublisherId = _publisherId
            }.Build();

            JsonStatusMessage willPayload = new()
            {
                MessageId = Guid.NewGuid().ToString(),
                PublisherId = _publisherId,
                Status = PubSubState.Error,
                IsCyclic = false
            };

            var json = JsonSerializer.Serialize(willPayload, new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault });

            var options = new MqttClientOptionsBuilder()
                .WithProtocolVersion(MqttProtocolVersion.V500)
                .WithTcpServer(Config.BrokerUrl, Config.BrokerPort)
                .WithWillTopic(willTopic)
                .WithWillRetain(true)
                .WithWillDelayInterval(60)
                .WithWillPayload(json)
                .WithClientId($"{Config.TopicPrefix}.{_publisherId}")
                .Build();

            var response = await _mqttClient.ConnectAsync(options, CancellationToken.None);

            if (response.ResultCode != MqttClientConnectResultCode.Success)
                logger.LogError($"Connect failed: {response.ResultCode} {response.ResultCode} {response.ReasonString}");
            else
            {
                logger.LogInformation("Publisher connected");

                _observers = new()
                {
                    [nameof(HarnessProgress.Housing)] = new(_lock)
                    {
                        Name = nameof(HarnessProgress.Housing),
                        Description = "Housing name of insertion",
                        NodeId = $"ns=2;i={HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_HousingName}",
                        StatusCode = StatusCodes.BadWaitingForInitialData,
                    },
                    [nameof(HarnessProgress.Cavity)] = new(_lock)
                    {
                        Name = nameof(HarnessProgress.Cavity),
                        Description = "Cavity of insertion",
                        NodeId = $"ns=2;i={HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_CavityNumber}",
                        StatusCode = StatusCodes.BadWaitingForInitialData,
                    },
                    [nameof(HarnessProgress.LeadSetEnd)] = new(_lock)
                    {
                        Name = nameof(HarnessProgress.LeadSetEnd),
                        Description = "Leadset number",
                        NodeId = $"ns=2;i={HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_LeadSetEnd}",
                        StatusCode = StatusCodes.BadWaitingForInitialData,
                    },
                    [nameof(CoordinationUnitProgress.ItemsProduced)] = new(_lock)
                    {
                        Name = nameof(CoordinationUnitProgress.ItemsProduced),
                        Description = "Total number of items produces",
                        NodeId = $"ns=2;i={HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_ItemsProduced}",
                        StatusCode = StatusCodes.BadWaitingForInitialData
                    },
                    [nameof(LeadSetProgress.LeadSetProduced)] = new(_lock)
                    {
                        Name = nameof(LeadSetProgress.LeadSetProduced),
                        Description = "Numbers of leadsets produced",
                        NodeId = $"ns=2;i={HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_LeadSetAssembler_LeadSetNumber}",
                        StatusCode = StatusCodes.BadWaitingForInitialData
                    }
                };

                _metadataVersion = GetVersionTime();

                await opcUaClient.Run(
                    new UAClientSettings()
                    {
                        ServerUrl = _opcUaServerUrl,
                        NoSecurity = true,
                        UserName = string.Empty,
                        Password = string.Empty,
                        AutoAccept = true
                    },
                    _observers.Values
                );

                await Publish();
            }

            opcUaClient?.Disconnect();
            await PublishStatus(PubSubState.Paused);
            await CleanupRetainedMessages();

            var disconnectOptions = _mqttFactory.CreateClientDisconnectOptionsBuilder().Build();
            await _mqttClient.DisconnectAsync(disconnectOptions, CancellationToken.None);
            Console.WriteLine("Publisher disconnected!");
        }
    }

    private async Task CleanupRetainedMessages()
    {
        if (_mqttClient == null || _mqttFactory == null) throw new InvalidOperationException();

        foreach (var topic in _retainedTopics)
        {
            var applicationMessage = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload("")
                .WithRetainFlag(true)
                .Build();

            var result = await _mqttClient.PublishAsync(applicationMessage, CancellationToken.None);
            if (result.IsSuccess)
                logger.LogInformation($"Retained message removed from {RED}{topic}{NORMAL}.");
            else
                logger.LogError($"Error: {result.ReasonCode} {result.ReasonString}");
        }
    }

    private static uint GetVersionTime()
    {
        return (uint)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
    }

    private async Task PublishStatus(PubSubState state)
    {
        if (_mqttClient == null || _mqttFactory == null) throw new InvalidOperationException();

        var topic = new Topic()
        {
            TopicPrefix = Config.TopicPrefix,
            MessageType = MessageTypes.Status,
            PublisherId = _publisherId
        }.Build();

        JsonStatusMessage payload = new()
        {
            MessageId = Guid.NewGuid().ToString(),
            PublisherId = _publisherId,
            Status = state,
            IsCyclic = false
        };

        var json = JsonSerializer.Serialize(payload, new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault });

        var applicationMessage = new MqttApplicationMessageBuilder()
            .WithTopic(topic)
            .WithPayload(json)
            .WithRetainFlag(true)
            .Build();

        var result = await _mqttClient.PublishAsync(applicationMessage, CancellationToken.None);

        if (result.IsSuccess)
            logger.LogInformation($"Message sent: {RED}{topic}{NORMAL}");
        else
            logger.LogError($"Error: {result.ReasonCode} {result.ReasonString}");
    }

    private async Task PublishDataSetMetaData(int count)
    {
        FieldMetaDataCollection fields = new();
        bool updateVersion = false;

        lock (_lock)
        {
            foreach (var value in _observers.Values)
            {
                var field = new FieldMetaData()
                {
                    Name = value.Name,
                    BuiltInType = (int)BuiltInType.Double,
                    DataType = new NodeId((int)BuiltInType.Double),
                    Description = new LocalizedText(value.Description),
                    ValueRank = -1,
                };

                if (value.Properties?.Count > 0)
                {
                    field.Properties = new();

                    foreach (var property in value.Properties)
                    {
                        field.Properties.Add(new Opc.Ua.KeyValuePair()
                        {
                            Key = new QualifiedName(property.Name),
                            Value = property.Value
                        });

                        if (property.IsDirty)
                        {
                            updateVersion = true;
                            property.IsDirty = false;
                        }
                    }
                }

                fields.Add(field);
            }
        }

        if (count % MetaDataPublishingCount != 0 && !updateVersion)
        {
            return;
        }

        var metadata = new DataSetMetaDataType()
        {
            Name = _dataSetName, // same name appears in the DataSetWriter.
            Description = new LocalizedText("Harness machine progress information"),
            Fields = fields
        };

        if (updateVersion)
        {
            _metadataVersion = GetVersionTime();
        }

        metadata.ConfigurationVersion = new ConfigurationVersionDataType()
        {
            MajorVersion = _metadataVersion,
            MinorVersion = _metadataVersion
        };

        JsonDataSetMetaDataMessage message = new()
        {
            MessageId = Guid.NewGuid().ToString(),
            PublisherId = _publisherId,
            DataSetWriterId = _dataSetWriterId,
            Timestamp = DateTime.UtcNow,
            MetaData = metadata
        };

        var json = message.Encode(MessageContext);

        var topic = new Topic()
        {
            TopicPrefix = Config.TopicPrefix,
            MessageType = MessageTypes.DataSetMetaData,
            PublisherId = _publisherId,
            GroupName = _groupName,
            WriterName = _writerName
        }.Build();

        var applicationMessage = new MqttApplicationMessageBuilder()
            .WithTopic(topic)
            .WithPayload(json)
            .WithRetainFlag(true)
            .Build();

        var result = await _mqttClient.PublishAsync(applicationMessage, CancellationToken.None);

        if (result.IsSuccess)
        {
            logger.LogInformation($"Message sent: {RED}{topic}{NORMAL}");
            _retainedTopics.Add(topic);
        }
        else
            logger.LogError($"Error: {result.ReasonCode} {result.ReasonString}");
    }

    private async Task PublishConnection()
    {
        if (_mqttClient == null || _mqttFactory == null) throw new InvalidOperationException();

        var connection = new PubSubConnectionDataType()
        {
            Name = _publisherId,
            PublisherId = _publisherId, // Used in the metadata topic names
            Enabled = true,
            WriterGroups = new()
            {
                new WriterGroupDataType()
                {
                    Name = _groupName, // Used in the metadata topic names
                    PublishingInterval = PublishingInterval,
                    KeepAliveTime = KeepAliveCount*KeepAliveCount,
                    HeaderLayoutUri = "http://opcfoundation.org/UA/PubSub-Layouts/JSON-DataSetMessage",
                    Enabled = true,
                    MessageSettings = new ExtensionObject(
                        new JsonWriterGroupMessageDataType()
                        {
                            // DataSetMessageHeader | SingleDataSetMessage 
                            NetworkMessageContentMask = 0x02 | 0x04 |0x08
                        }
                    ),
                    TransportSettings = new ExtensionObject(
                        new BrokerWriterGroupTransportDataType()
                        {
                            // have to publish the Data topic name even if the standard topic is used since the subscriber is expected to
                            // use this field to find the data. This value may be overridden at the DataSetWriter level.
                            QueueName = new Topic()
                            {
                                TopicPrefix = Config.TopicPrefix,
                                MessageType = MessageTypes.Data,
                                PublisherId = _publisherId,
                                GroupName = _groupName
                            }.Build()
                        }
                    ),
                    DataSetWriters = new()
                    {
                        new DataSetWriterDataType()
                        {
                            Name = _writerName, // Used in the metadata topic names.
                            DataSetFieldContentMask = 0x01 | 0x02, // StatusCode | SourceTimestamp
                            KeyFrameCount = KeyFrameCount,
                            Enabled = true,
                            DataSetName = _dataSetName,
                            DataSetWriterId = 101, // Unique across all Writers which are part of the Connection.
                            MessageSettings = new ExtensionObject(
                                new Opc.Ua.JsonDataSetWriterMessageDataType()
                                {
                                     // DataSetWriterId | SequenceNumber | Timestamp | Status | PublisherId | MinorVersion   
                                     DataSetMessageContentMask = 0x01 | 0x04 | 0x08 | 0x10 | 0x100 | 0x400
                                }
                            ),
                            TransportSettings = new ExtensionObject(
                                new BrokerDataSetWriterTransportDataType()
                                {
                                    // have to publish the MetaData topic name even if the standard topic is used
                                    // since the subscriber is expected to use this field to find the metadata. 
                                    MetaDataQueueName = new Topic()
                                    {
                                        TopicPrefix = Config.TopicPrefix,
                                        MessageType = MessageTypes.DataSetMetaData,
                                        PublisherId = _publisherId,
                                        GroupName = _groupName,
                                        WriterName = _writerName
                                    }.Build(),
                                    MetaDataUpdateTime = MetaDataPublishingCount*PublishingInterval
                                }
                            )
                        }
                    }
                }
            }
        };

        var topic = new Topic()
        {
            TopicPrefix = Config.TopicPrefix,
            MessageType = MessageTypes.Connection,
            PublisherId = _publisherId
        }.Build();

        JsonPubSubConnectionMessage message = new()
        {
            MessageId = Guid.NewGuid().ToString(),
            PublisherId = _publisherId,
            Timestamp = DateTime.UtcNow,
            Connection = connection
        };

        var json = message.Encode(MessageContext);

        var applicationMessage = new MqttApplicationMessageBuilder()
            .WithTopic(topic)
            .WithPayload(json)
            .WithRetainFlag(true)
            .Build();

        var result = await _mqttClient.PublishAsync(applicationMessage, CancellationToken.None);

        if (result.IsSuccess)
        {
            logger.LogInformation($"Message sent: {RED}{topic}{NORMAL}");
            _retainedTopics.Add(topic);
        }
        else
            logger.LogError($"Error: {result.ReasonCode} {result.ReasonString}");
    }

    private async Task Publish()
    {
        if (_mqttClient == null || _mqttFactory == null) 
            throw new InvalidOperationException();

        await PublishStatus(PubSubState.Operational);
        await PublishConnection();

        int count = 0;
        int lastDataCount = 0;

        while (true)
        {
            await PublishDataSetMetaData(count);

            JsonDataSetMessage message = new()
            {
                PublisherId = _publisherId,
                DataSetWriterId = _dataSetWriterId,
                Timestamp = DateTime.UtcNow,
                SequenceNumber = (uint)(count + 1),
                MinorVersion = _metadataVersion,
                MessageType = (count % KeyFrameCount == 0) ? "ua-keyframe" : "ua-deltaframe",
                Payload = new()
            };

            lock (_lock)
            {
                var values = _observers.Values.ToArray();

                if (!values.Where(v => v.IsDirty).Any())
                {
                    if ((count - lastDataCount) % KeepAliveCount != 0)
                    {
                        count++;
                        continue;
                    }
                    message.MessageType = "ua-keepalive";
                }
                else
                {
                    foreach (var value in values)
                    {
                        if (count % KeyFrameCount == 0 || value.IsDirty)
                        {
                            using (var encoder = new JsonEncoder(MessageContext, false))
                            {
                                encoder.WriteDataValue(null, new DataValue()
                                {
                                    WrappedValue = value.Value,
                                    SourceTimestamp = value.Timestamp,
                                    ServerTimestamp = DateTime.MinValue,
                                    StatusCode = value.StatusCode
                                });
                                message.Payload[value.Name] = JsonNode.Parse(encoder.CloseAndReturnText());
                            }
                            value.IsDirty = false;
                        }
                    }
                    lastDataCount++;
                }
            }

            var json = message.Encode(MessageContext);

            var topic = new Topic()
            {
                TopicPrefix = Config.TopicPrefix,
                MessageType = MessageTypes.Data,
                PublisherId = _publisherId,
                GroupName = _groupName
            }.Build();

            var dataMessage = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(json)
                .Build();

            var result = await _mqttClient.PublishAsync(dataMessage, CancellationToken.None);

            if (result.IsSuccess)
            {
                logger.LogInformation($"Message sent: {RED}{topic}{NORMAL} ({message.MessageType})");
                count++;
            }
            else
                logger.LogError($"Error: {result.ReasonCode} {result.ReasonString}");

            await Task.Delay(PublishingInterval);
        }
    }
}
