using Domain;
using Opc.Ua;

namespace OpcUaServer.Server;

internal class NativeProductionServices(CustomNodeManager nodeManager)
{
    internal void Publish(CoordinationUnitProgress progress)
    {
        var harnessNode = (BaseDataVariableState)nodeManager.FindNodeInAddressSpace(new NodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_ItemsProduced, nodeManager.NamespaceIndexes[0]));
        harnessNode.Value = progress.ItemsProduced;
        harnessNode.ClearChangeMasks(nodeManager.SystemContext, false);
    }

    internal void Publish(LeadSetProgress progress)
    {
        var leadsetNode = (BaseDataVariableState)nodeManager.FindNodeInAddressSpace(new NodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_LeadSetAssembler_LeadSetNumber, nodeManager.NamespaceIndexes[0]));
        leadsetNode.Value = progress.LeadSetProduced;
        leadsetNode.ClearChangeMasks(nodeManager.SystemContext, false);
    }

    internal void Publish(HarnessProgress progress)
    {
        var leadsetNode = (BaseDataVariableState)nodeManager.FindNodeInAddressSpace(new NodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_LeadSetEnd, nodeManager.NamespaceIndexes[0]));
        leadsetNode.Value = progress.LeadSetEnd;
        leadsetNode.ClearChangeMasks(nodeManager.SystemContext, false);

        var harnessNode = (BaseDataVariableState)nodeManager.FindNodeInAddressSpace(new NodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_CavityNumber, nodeManager.NamespaceIndexes[0]));
        harnessNode.Value = progress.Cavity;
        harnessNode.ClearChangeMasks(nodeManager.SystemContext, false);

        harnessNode = (BaseDataVariableState)nodeManager.FindNodeInAddressSpace(new NodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_HousingName, nodeManager.NamespaceIndexes[0]));
        harnessNode.Value = progress.Housing;
        harnessNode.ClearChangeMasks(nodeManager.SystemContext, false);
    }
}
