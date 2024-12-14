using System.Runtime.Serialization;
using HarnessMachine;

namespace OpcUaServer.Server;

[DataContract(Namespace = Namespaces.HarnessMachine)]
public class CustomServerConfig
{
    [DataMember] public string InstanceName { get; set; } = "Example Instance";

    [DataMember] public string Manufacturer { get; set; } = "Demo Inc.";

    [DataMember] public string SerialNumber { get; set; } = "ABC.123.XYZ";

    public CustomServerConfig()
    {
        Initialize();
    }

    [OnDeserializing()]
    private void Initialize(StreamingContext context)
    {
        Initialize();
    }

    private void Initialize()
    {
    }
}