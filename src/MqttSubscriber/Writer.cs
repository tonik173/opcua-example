using Opc.Ua;

namespace MqttSubscriber;

internal class Writer
{
    public string PublisherId { get; set; }
    public string WriterName { get; set; }
    public int? DataSetWriterId { get; set; }
    public WriterGroupDataType WriterGroup { get; set; }
    public DataSetWriterDataType DataSetWriter { get; set; }
    public DataSetMetaDataType DataSetMetaData { get; set; }
    public Dictionary<string, string> EngineeringUnits { get; set; } = new();
    public string MetaDataTopic { get; set; }
}