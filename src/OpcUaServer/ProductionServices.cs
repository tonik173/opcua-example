using Domain;
using OpcUaServer.Server;

namespace OpcUaServer;

public class ProductionServices
{
    private NativeProductionServices? _nativeProductionServices;

    public async Task Publish<T>(T progress)
    {
        await Task.Run(() =>
        {
            if (_nativeProductionServices != null)
            {
                switch (progress)
                {
                    case CoordinationUnitProgress coordinationUnitProgress:
                        _nativeProductionServices.Publish(coordinationUnitProgress);
                        break;
                    case LeadSetProgress leadSetProgress:
                        _nativeProductionServices.Publish(leadSetProgress);
                        break;
                    case HarnessProgress harnessProgress:
                        _nativeProductionServices.Publish(harnessProgress);
                        break;
                }
            }
        });
    }

    internal void RegisterNativeProductionServices(NativeProductionServices nativeProductionServices)
    {
        _nativeProductionServices = nativeProductionServices;
    }
}
