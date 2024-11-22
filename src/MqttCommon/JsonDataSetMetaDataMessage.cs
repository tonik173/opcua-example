using Opc.Ua;

namespace MqttCommon;

public class JsonDataSetMetaDataMessage
{
    public JsonDataSetMetaDataMessage()
    {
        MessageType = "ua-metadata";
    }

    public string MessageId { get; set; }
    public string MessageType { get; set; }
    public string PublisherId { get; set; }
    public ushort? DataSetWriterId { get; set; }
    public string DataSetWriterName { get; set; }
    public DateTime? Timestamp { get; set; }
    public DataSetMetaDataType MetaData { get; set; }

    public static JsonDataSetMetaDataMessage Decode(IServiceMessageContext context, string json)
    {
        JsonDataSetMetaDataMessage value = new();
        value.MessageType = null;

        using (var decoder = new JsonDecoder(json, context))
        {
            value.MessageId = decoder.ReadString(nameof(MessageId));
            value.MessageType = decoder.ReadString(nameof(MessageType));
            value.PublisherId = decoder.ReadString(nameof(PublisherId));
            value.DataSetWriterId = decoder.ReadUInt16(nameof(DataSetWriterId));
            value.DataSetWriterName = decoder.ReadString(nameof(DataSetWriterName));
            value.Timestamp = decoder.ReadDateTime(nameof(Timestamp));
            if (value.Timestamp == DateTime.MinValue) value.Timestamp = null;
            value.MetaData = (DataSetMetaDataType)decoder.ReadEncodeable(nameof(MetaData), typeof(DataSetMetaDataType));
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
            if (DataSetWriterId != null) encoder.WriteUInt16(nameof(DataSetWriterId), DataSetWriterId ?? 0);
            if (DataSetWriterName != null) encoder.WriteString(nameof(DataSetWriterName), DataSetWriterName);
            if (Timestamp != null) encoder.WriteDateTime(nameof(Timestamp), Timestamp ?? DateTime.MinValue);

            encoder.WriteEncodeable(nameof(MetaData), MetaData, typeof(DataSetMetaDataType));
            return encoder.CloseAndReturnText();
        }
    }
}
