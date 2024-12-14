using Microsoft.Extensions.Logging;
using Opc.Ua;
using Opc.Ua.Server;

namespace OpcUaServer.Server;

public class CustomServer(ILogger<OpcUaServerApp> logger, ProductionServices productionServices) : StandardServer
{
    internal CustomNodeManager CustomNodeManager { get; private set; } = null!;

    protected override MasterNodeManager CreateMasterNodeManager(
        IServerInternal server, ApplicationConfiguration configuration)
    {
        List<INodeManager> nodeManagers = new();

        // create the custom node managers.
        CustomNodeManager = new(server, configuration, productionServices, logger);
        nodeManagers.Add(CustomNodeManager);

        // create master node manager.
        return new MasterNodeManager(server, configuration, null, nodeManagers.ToArray());
    }

    protected override ServerProperties LoadServerProperties()
    {
        ServerProperties properties = new();

        properties.ManufacturerName = "Demo Inc";
        properties.ProductName = "Harness Machine OpcUa Server";
        properties.ProductUri = "http://example.com/HarnessMachine/";
        properties.SoftwareVersion = Utils.GetAssemblySoftwareVersion();
        properties.BuildNumber = Utils.GetAssemblyBuildNumber();
        properties.BuildDate = Utils.GetAssemblyTimestamp();

        return properties;
    }
}
