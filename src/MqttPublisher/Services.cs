using Microsoft.Extensions.DependencyInjection;

namespace MqttPublisher;

public class Services
{
    public static void AddServices(IServiceCollection services)
    {
        services.AddSingleton<OpcUaClient>();
        services.AddSingleton<Publisher>();
    }
}