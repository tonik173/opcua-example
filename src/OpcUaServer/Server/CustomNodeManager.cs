using HarnessMachine;
using System.Reflection;
using Microsoft.Extensions.Logging;
using Opc.Ua;
using Opc.Ua.Server;

namespace OpcUaServer.Server;

internal class CustomNodeManager : CustomNodeManager2
{
    private readonly CustomServerConfig _configuration;
    private HarnessMachineState Machine = null!;
    private readonly ProductionServices ProductionServices;
    private readonly NativeProductionServices NativeProductionServices;
    private readonly ILogger<OpcUaServerApp> _logger;
    private string[] namespaceUrls = new string[2];

    public CustomNodeManager(IServerInternal server,
        ApplicationConfiguration configuration,
        ProductionServices productionServices,
        ILogger<OpcUaServerApp> logger)
        : base(server, configuration)
    {
        SystemContext.NodeIdFactory = this;
        NativeProductionServices = new(this);
        ProductionServices = productionServices;
        _logger = logger;

        // set one namespace for the type model and one names for dynamically created nodes.
        namespaceUrls[0] = HarnessMachine.Namespaces.HarnessMachine;
        namespaceUrls[1] = HarnessMachine.Namespaces.HarnessMachine + "/Instance";
        SetNamespaces(namespaceUrls);

        // get the configuration for the node manager.
        _configuration = configuration.ParseExtension<CustomServerConfig>() ?? new CustomServerConfig();
    }

    protected override NodeStateCollection LoadPredefinedNodes(ISystemContext context)
    {
        NodeStateCollection predefinedNodes = new NodeStateCollection();

        try
        {
            predefinedNodes.LoadFromBinaryResource(context,
                "OpcUaServer.OpcUaModel.DI.DI.Opc.Ua.DI.PredefinedNodes.uanodes",
                typeof(CustomNodeManager).GetTypeInfo().Assembly,
                true);

            predefinedNodes.LoadFromBinaryResource(context,
                "OpcUaServer.OpcUaModel.Machinery.Machinery.Opc.Ua.Machinery.PredefinedNodes.uanodes",
                typeof(CustomNodeManager).GetTypeInfo().Assembly,
                true);

            predefinedNodes.LoadFromBinaryResource(context,
                "OpcUaServer.OpcUaModel.HarnessMachine.HarnessMachine.HarnessMachine.PredefinedNodes.uanodes",
                typeof(CustomNodeManager).GetTypeInfo().Assembly,
                true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Could not load uanodes");
        }

        return predefinedNodes;
    }

    public override void CreateAddressSpace(IDictionary<NodeId, IList<IReference>> externalReferences)
    {
        lock (Lock)
        {
            LoadPredefinedNodes(SystemContext, externalReferences);

            // find the untyped Omega node that was created when the model was loaded.
            BaseObjectState passiveNode = (BaseObjectState)FindPredefinedNode(new NodeId(HarnessMachine.Objects.Machines_HarnessMachine, NamespaceIndexes[0]), typeof(BaseObjectState));

            // convert the untyped node to a typed node that can be manipulated within the server.
            Machine = new HarnessMachineState(null);
            Machine.Create(SystemContext, passiveNode);

            // replaces the untyped predefined nodes with their strongly typed versions.
            AddPredefinedNode(SystemContext, Machine);

            _logger.LogInformation("Address space created");


            ProductionServices.RegisterNativeProductionServices(NativeProductionServices);

            // identification (just a test)
            var serialNumberNode = (PropertyState)FindNodeInAddressSpace(new NodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Identification_SerialNumber, NamespaceIndexes[0]));
            serialNumberNode.Value = _configuration.SerialNumber;
            serialNumberNode.ClearChangeMasks(SystemContext, false);
            var manufacturerNode = (PropertyState)FindNodeInAddressSpace(new NodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Identification_Manufacturer, NamespaceIndexes[0]));
            manufacturerNode.Value = _configuration.Manufacturer;
            manufacturerNode.ClearChangeMasks(SystemContext, false);
            var prodInstNode = (PropertyState)FindNodeInAddressSpace(new NodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Identification_ProductInstanceUri, NamespaceIndexes[0]));
            prodInstNode.Value = _configuration.InstanceName;
            prodInstNode.ClearChangeMasks(SystemContext, false);

            _logger.LogInformation("Machine information written");
        }
    }
}
