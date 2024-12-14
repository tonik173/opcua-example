using Microsoft.Extensions.DependencyInjection;
using OpcUaServer.Server;

namespace OpcUaServer;

public class Services
{
    public static void AddServices(IServiceCollection services)
    {
        services.AddSingleton<OpcUaServerApp>();
        services.AddSingleton<CustomServer>();
        services.AddSingleton<ProductionServices>();
    }
}

