using Microsoft.Extensions.DependencyInjection;

namespace MqttSubscriber;

public class Services
{
    public static void AddServices(IServiceCollection services)
    {
        services.AddSingleton<Subscriber>();
    }
}