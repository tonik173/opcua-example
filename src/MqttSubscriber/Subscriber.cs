using Microsoft.Extensions.Logging;
using MqttCommon;
using MQTTnet;
using MQTTnet.Client;
using Opc.Ua;
using System.Text;
using System.Text.Json.Nodes;

namespace MqttSubscriber;

public class Subscriber(ILogger<Subscriber> logger)
{
    private ServiceMessageContext _context;
    private MqttFactory _factory;
    private IMqttClient _client;
    private readonly Dictionary<string, Writer> _writers = new();
    private readonly Dictionary<string, Group> _groups = new();

    public async Task Connect()
    {
        _context = new ServiceMessageContext();
        _factory = new MqttFactory();

        _client = _factory.CreateMqttClient();

        var options = new MqttClientOptionsBuilder().WithTcpServer(Config.BrokerUrl, Config.BrokerPort).Build();
        var response = await _client.ConnectAsync(options, CancellationToken.None);

        if (response.ResultCode == MqttClientConnectResultCode.Success)
            logger.LogInformation("Subscriber connected");
        else
            logger.LogError($"Connect failed: {response.ResultCode} {response.ResultCode} {response.ReasonString}");

        _client.ApplicationMessageReceivedAsync += async delegate (MqttApplicationMessageReceivedEventArgs args)
        {
            string topic = args.ApplicationMessage.Topic;
            logger.LogInformation($"Received on topic: {topic}");

            if (topic.StartsWith($"{Config.TopicPrefix}/json/{MessageTypes.Status}"))
                await HandleStatus(args.ApplicationMessage);
            else if (topic.StartsWith($"{Config.TopicPrefix}/json/{MessageTypes.Connection}"))
                await HandleConnection(args.ApplicationMessage);
            else if (topic.StartsWith($"{Config.TopicPrefix}/json/{MessageTypes.DataSetMetaData}"))
                await HandleDataSetMetaData(args.ApplicationMessage);
            else
                await HandleData(args.ApplicationMessage);
        };

        await Subscribe(new Topic()
        {
            TopicPrefix = Config.TopicPrefix,
            MessageType = MessageTypes.Status,
            PublisherId = "#"
        }.Build());
    }

    public async Task Disconnect()
    {
        var disconnectOptions = _factory.CreateClientDisconnectOptionsBuilder().Build();
        await _client.DisconnectAsync(disconnectOptions, CancellationToken.None);
        _client.Dispose();
        logger.LogInformation("Subscriber disconnected");
    }

    private async Task Subscribe(string topic)
    {
        if (_client == null || _factory == null) throw new InvalidOperationException();

        var options = _factory.CreateSubscribeOptionsBuilder()
            .WithTopicFilter(f => { f.WithTopic(topic); })
            .Build();

        var response = await _client.SubscribeAsync(options, CancellationToken.None);

        if (string.IsNullOrEmpty(response?.ReasonString))
            logger.LogInformation($"Subscribed: '{topic}'.");
        else
            logger.LogError($"Subscribe failed: '{response?.ReasonString}'.");
    }
    private async Task Unsubscribe(string topic)
    {
        if (_client == null || _factory == null) throw new InvalidOperationException();

        var options = _factory.CreateUnsubscribeOptionsBuilder()
            .WithTopicFilter(topic)
            .Build();

        var response = await _client.UnsubscribeAsync(options, CancellationToken.None);

        if (string.IsNullOrEmpty(response?.ReasonString))
            logger.LogInformation($"Unsubscribed: '{topic}'.");
        else
            logger.LogError($"Unsubscribe failed: '{response?.ReasonString}'.");
    }

    private void WriteFieldValue(string name, DataSetField field, Writer writer)
    {
        StringBuilder sb = new("<== ");

        if (field?.SourceTimestamp != null)
            sb.Append($"[{field?.SourceTimestamp:HH:mm:ss}] ");

        if (StatusCode.IsNotGood(field.StatusCode ?? 0))
            sb.Append($"{name}=[{field?.StatusCode}] ");

        if (field?.Value is JsonObject @object)
        {
            if (@object.ContainsKey("Body"))
                sb.Append($"{name}={@object["Body"]}");
            else
                sb.Append($"{name}={@object}");
        }
        else
            sb.Append($"{name}={field?.Value}");

        if (writer != null)
        {
            lock (_writers)
            {
                if (writer.EngineeringUnits.TryGetValue(name, out var unit))
                    sb.Append($" {unit}");
            }
        }

        logger.LogInformation(sb.ToString());
    }

    private void HandleDataSetMessage(Topic topic, JsonDataSetMessage dm)
    {
        var publisherId = $"{dm?.PublisherId}";

        if (!dm.ExcludeHeader)
            logger.LogInformation($"PublisherId: {publisherId}, {dm?.MessageType}, {dm?.SequenceNumber}");

        if (dm.Payload != null)
        {
            Writer writer = null;

            // find the writer using information in the header.
            if (!dm.ExcludeHeader)
            {
                var writerId = $"{publisherId}.{dm?.DataSetWriterId}";
                lock (_writers)
                {
                    if (!_writers.TryGetValue(writerId, out writer))
                        logger.LogWarning($"[Writer for Data message not found: {writerId}]");
                }
            }
            // find the writer using information in the topic.
            else
            {
                var groupId = $"{topic?.PublisherId}.{topic?.GroupName}";

                lock (_writers)
                {
                    if (_groups.TryGetValue(groupId, out var group))
                        writer = group.Writers.Where(x => x.WriterName == topic?.WriterName).FirstOrDefault();
                }

                if (writer == null)
                    logger.LogWarning($"[Writer for Data message not found: {topic?.WriterName}]");
            }

            foreach (var item in dm.Payload)
            {
                var field = DataSetField.Decode(_context, item.Value.ToJsonString());
                WriteFieldValue(item.Key, field, writer);
            }
        }
    }

    private Task HandleData(MqttApplicationMessage message)
    {
        byte[] payload = message.PayloadSegment.Array;

        if (payload != null)
        {
            var json = Encoding.UTF8.GetString(payload);
            try
            {
                var nm = JsonNetworkMessage.Decode(_context, json);
                if (nm?.Messages != null)
                {
                    var topic = Topic.Parse(message.Topic);
                    foreach (var dm in nm.Messages)
                    {
                        HandleDataSetMessage(topic, dm);
                    }
                }
            }
            catch (Exception e)
            {
                logger.LogError($"Parsing failed: '{e.Message}' [{json}]");
            }
        }

        return Task.CompletedTask;
    }

    private async Task HandleStatus(MqttApplicationMessage message)
    {
        byte[] payload = message.PayloadSegment.Array;
        if (payload != null)
        {
            var json = Encoding.UTF8.GetString(payload);
            try
            {
                var status = JsonStatusMessage.Decode(_context, json);
                logger.LogInformation($"{status?.PublisherId}: Status={((status?.Status != null) ? status.Status.Value : "")}");

                var connectionTopic = new Topic()
                {
                    TopicPrefix = Config.TopicPrefix,
                    MessageType = MessageTypes.Connection,
                    PublisherId = status?.PublisherId
                }.Build();

                if (status?.Status == PubSubState.Operational)
                    await Subscribe(connectionTopic);
                else
                {
                    await Unsubscribe(connectionTopic);

                    // unsubscribe from all data topics for this publisher.
                    List<string> topics = new();

                    lock (_writers)
                    {
                        foreach (var group in _groups.Values)
                        {
                            if (group.PublisherId == status?.PublisherId)
                            {
                                if (group.DataTopic != null)
                                    topics.Add(group.DataTopic);

                                foreach (var writer in group.Writers)
                                {
                                    if (writer.MetaDataTopic != null)
                                        topics.Add(writer.MetaDataTopic);
                                }
                            }
                        }
                    }

                    foreach (var topic in topics)
                    {
                        await Unsubscribe(topic);
                    }
                }
            }
            catch (Exception e)
            {
                logger.LogError($"Parsing failed: '{e.Message}' [{json}]");
            }
        }
    }

    private Task HandleDataSetMetaData(MqttApplicationMessage message)
    {
        byte[] payload = message.PayloadSegment.Array;

        if (payload != null)
        {
            var json = Encoding.UTF8.GetString(payload);
            try
            {
                var metadata = JsonDataSetMetaDataMessage.Decode(_context, json);
                var writerId = $"{metadata?.PublisherId}.{metadata?.DataSetWriterId}";
                var source = metadata?.MetaData?.Fields;

                logger.LogInformation($"DataSetMetaData Message: '{writerId}'");

                if (source != null)
                {
                    lock (_writers)
                    {
                        if (!_writers.TryGetValue(writerId, out var writer))
                        {
                            writer = new Writer()
                            {
                                PublisherId = metadata?.PublisherId,
                                DataSetMetaData = metadata?.MetaData
                            };

                            _writers[writerId] = writer;
                        }

                        Dictionary<string, string> fields = writer.EngineeringUnits;
                        foreach (var field in source)
                        {
                            if (field.Name == null || field.Properties == null)
                                continue;

                            var value = field.Properties
                                .Where(x => x.Key?.Name == BrowseNames.EngineeringUnits)
                                .Select(x => x.Value)
                                .FirstOrDefault();

                            if (value != Variant.Null)
                            {
                                var eu = ExtensionObject.ToEncodeable((ExtensionObject)value.Value) as EUInformation;
                                if (eu != null)
                                    fields[field.Name] = eu.DisplayName.Text;
                            }
                        }

                        writer.EngineeringUnits = fields;
                    }
                }
            }
            catch (Exception e)
            {
                logger.LogError($"Parsing failed: '{e.Message}' [{json}]");
            }
        }

        return Task.CompletedTask;
    }

    public async Task HandleConnection(MqttApplicationMessage message)
    {
        byte[] payload = message.PayloadSegment.Array;

        if (payload == null) return;

        JsonPubSubConnectionMessage connection;
        var json = Encoding.UTF8.GetString(payload);

        try
        {
            connection = JsonPubSubConnectionMessage.Decode(_context, json);
        }
        catch (Exception e)
        {
            logger.LogError($"Parsing failed: '{e.Message}' [{json}]");
            return;
        }

        if (connection?.Connection?.WriterGroups != null)
        {
            foreach (var writerGroup in connection.Connection.WriterGroups)
            {
                var groupId = $"{connection?.PublisherId}.{writerGroup?.Name}";
                Group group = null;

                lock (_writers)
                {
                    if (!_groups.TryGetValue(groupId, out group))
                    {
                        group = new Group()
                        {
                            PublisherId = connection?.PublisherId,
                            GroupName = writerGroup?.Name
                        };
                        _groups[groupId] = group;
                    }
                }

                group.HasNetworkMessageHeader = false;
                group.HasDataSetMessageHeader = false;
                group.HasMultipleDataSetMessages = false;
                group.DataTopic = null;

                if (writerGroup?.MessageSettings?.Body is JsonWriterGroupMessageDataType wgm)
                {
                    var mask = wgm.NetworkMessageContentMask;
                    group.HasNetworkMessageHeader = (mask & 0x01) != 0;
                    group.HasDataSetMessageHeader = (mask & 0x02) != 0;
                    group.HasMultipleDataSetMessages = (mask & 0x04) == 0;
                }

                if (writerGroup?.TransportSettings?.Body is BrokerWriterGroupTransportDataType wgt)
                {
                    group.DataTopic = wgt.QueueName;
                }

                if (group.DataTopic == null)
                {
                    group.DataTopic = new Topic()
                    {
                        TopicPrefix = Config.TopicPrefix,
                        MessageType = MessageTypes.Data,
                        PublisherId = connection?.PublisherId,
                        GroupName = writerGroup?.Name,
                        WriterName = "#"
                    }.Build();
                }

                // this example is only interested in data messages with multiple messages.
                if (!group.HasMultipleDataSetMessages && !group.HasNetworkMessageHeader)
                    await Subscribe(group.DataTopic);

                if (writerGroup?.DataSetWriters != null)
                {
                    foreach (var jj in writerGroup.DataSetWriters)
                    {
                        string metadataTopic = null;

                        if (jj?.TransportSettings?.Body is BrokerDataSetWriterTransportDataType dwt)
                        {
                            metadataTopic = dwt.MetaDataQueueName;
                        }

                        if (metadataTopic == null)
                        {
                            metadataTopic = new Topic()
                            {
                                TopicPrefix = Config.TopicPrefix,
                                MessageType = MessageTypes.DataSetMetaData,
                                PublisherId = connection?.PublisherId,
                                GroupName = writerGroup?.Name,
                                WriterName = jj?.Name
                            }.Build();
                        }

                        lock (_writers)
                        {
                            var writerId = $"{connection?.PublisherId}.{jj?.DataSetWriterId}";

                            if (!_writers.TryGetValue(writerId, out var writer))
                            {
                                writer = new Writer()
                                {
                                    PublisherId = connection?.PublisherId,
                                    DataSetWriterId = jj?.DataSetWriterId,
                                };

                                _writers[writerId] = writer;
                                group.Writers.Add(writer);
                            }

                            writer.MetaDataTopic = metadataTopic;
                            writer.WriterGroup = writerGroup;
                            writer.DataSetWriter = jj;
                        }

                        await Subscribe(metadataTopic);
                    }
                }
            }
        }
    }
}
