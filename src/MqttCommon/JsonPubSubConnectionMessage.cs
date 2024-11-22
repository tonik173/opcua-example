
using Opc.Ua;

namespace MqttCommon;

public class JsonPubSubConnectionMessage
{
    public JsonPubSubConnectionMessage()
    {
        MessageType = "ua-connection";
    }

    public string MessageId { get; set; }
    public string MessageType { get; set; }
    public string PublisherId { get; set; }
    public DateTime? Timestamp { get; set; }
    public PubSubConnectionDataType Connection { get; set; }

    public static JsonPubSubConnectionMessage Decode(IServiceMessageContext context, string json)
    {
        JsonPubSubConnectionMessage value = new();
        value.MessageType = null;

        using (var decoder = new JsonDecoder(json, context))
        {
            value.MessageId = decoder.ReadString(nameof(MessageId));
            value.MessageType = decoder.ReadString(nameof(MessageType));
            value.PublisherId = decoder.ReadString(nameof(PublisherId));
            value.Timestamp = decoder.ReadDateTime(nameof(Timestamp));
            if (value.Timestamp == DateTime.MinValue) value.Timestamp = null;
            value.Connection = (PubSubConnectionDataType)decoder.ReadEncodeable(nameof(Connection), typeof(PubSubConnectionDataType));
        }

        return value;
    }

    public string Encode(IServiceMessageContext context)
    {
        using (var encoder = new JsonEncoder(context, true))
        {
            if (MessageId != null) encoder.WriteString(nameof(MessageId), MessageId);
            if (MessageType != null) encoder.WriteString(nameof(MessageType), MessageType);
            if (PublisherId != null) encoder.WriteString(nameof(PublisherId), PublisherId);
            if (Timestamp != null) encoder.WriteDateTime(nameof(Timestamp), Timestamp ?? DateTime.MinValue);

            encoder.WriteEncodeable(nameof(Connection), Connection, typeof(PubSubConnectionDataType));
            return encoder.CloseAndReturnText();
        }
    }
}
