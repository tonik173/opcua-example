
using Opc.Ua;

namespace MqttCommon;

public class JsonStatusMessage
{
    public JsonStatusMessage()
    {
        MessageType = "ua-status";
    }

    public string MessageId { get; set; }
    public string MessageType { get; set; }
    public string PublisherId { get; set; }
    public DateTime? Timestamp { get; set; }
    public bool? IsCyclic { get; set; }
    public PubSubState? Status { get; set; }
    public DateTime? NextReportTime { get; set; }

    public static JsonStatusMessage Decode(IServiceMessageContext context, string json)
    {
        JsonStatusMessage value = new();
        value.MessageType = null;

        using (var decoder = new JsonDecoder(json, context))
        {
            value.MessageId = decoder.ReadString(nameof(MessageId));
            value.MessageType = decoder.ReadString(nameof(MessageType));
            value.PublisherId = decoder.ReadString(nameof(PublisherId));
            value.Timestamp = decoder.ReadDateTime(nameof(Timestamp));
            if (value.Timestamp == DateTime.MinValue) value.NextReportTime = null;
            value.IsCyclic = decoder.ReadBoolean(nameof(IsCyclic));
            value.Status = (PubSubState)decoder.ReadInt32(nameof(Status));
            value.NextReportTime = decoder.ReadDateTime(nameof(NextReportTime));
            if (value.NextReportTime == DateTime.MinValue) value.NextReportTime = null;
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
            if (IsCyclic != null) encoder.WriteBoolean(nameof(IsCyclic), IsCyclic ?? false);
            if (Status != null) encoder.WriteInt32(nameof(Status), (int)(Status ?? PubSubState.Error));
            if (NextReportTime != null) encoder.WriteDateTime(nameof(NextReportTime), NextReportTime ?? DateTime.MinValue);

            return encoder.CloseAndReturnText();
        }
    }
}
