namespace MqttSubscriber;

internal class Group
{
    public string PublisherId { get; set; }
    public string GroupName { get; set; }
    public bool HasNetworkMessageHeader { get; set; }
    public bool HasDataSetMessageHeader { get; set; }
    public bool HasMultipleDataSetMessages { get; set; }
    public string DataTopic { get; set; }
    public List<Writer> Writers { get; set; } = new();
}