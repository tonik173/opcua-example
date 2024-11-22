using Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MqttPublisher;
using MqttSubscriber;
using OpcUaServer;
using OpcUaServer.Server;

namespace SimulationHost;

public class Simulation(IServiceProvider hostServices, ILogger<Simulation> logger, ILoggerFactory loggerFactory) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        OpcUaServerApp server = hostServices.GetService<OpcUaServerApp>() ?? throw new Exception("OpcUaServer not registered.");
        await server.Initialize();

        // changes values on the opc ua server
        int numOfPublishMessages = 500;
        ProductionServices productionSerivces = hostServices.GetService<ProductionServices>() ?? throw new Exception("ProductionServices not registered.");
        Task.Run(async () =>
        {
            while (numOfPublishMessages-- > 0)
            {
                await productionSerivces.Publish(LeadSetProgress.CreateSample());
                await productionSerivces.Publish(LeadSetProgress.CreateSample());

                await productionSerivces.Publish(HarnessProgress.CreateSample());
                await productionSerivces.Publish(HarnessProgress.CreateSample());
                await productionSerivces.Publish(HarnessProgress.CreateSample());
                await productionSerivces.Publish(HarnessProgress.CreateSample());

                await productionSerivces.Publish(CoordinationUnitProgress.CreateSample());

                await Task.Delay(2000);
            }
        }).ConfigureAwait(false).GetAwaiter();

        // starts listening on mqtt messages
        Subscriber subscriber = hostServices.GetService<Subscriber>() ?? throw new Exception("Subscriber not registered.");
        await subscriber.Connect();

        // starts the publisher, which observes some nodes on the server
        Publisher publisher = hostServices.GetService<Publisher>() ?? throw new Exception("Publisher not registered.");
        await publisher.Connect();
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
    }
}