using Microsoft.Extensions.Logging;
using Opc.Ua;
using Opc.Ua.Configuration;

namespace OpcUaServer.Server;

public class OpcUaServerApp(CustomServer customServer, ILogger<OpcUaServerApp> logger)
{

    private ApplicationInstance? _applicationServerInstance;

    public async Task Initialize()
    {
        _applicationServerInstance = new ApplicationInstance
        {
            ApplicationType = ApplicationType.Server,
            ConfigSectionName = "_OpcUaServer"
        };

        await _applicationServerInstance.LoadApplicationConfiguration(false);
        if (!await _applicationServerInstance.CheckApplicationInstanceCertificate(false, 0))
        {
            logger.LogError($"CheckApplicationInstanceCertificate failed");
        }

        await _applicationServerInstance.Start(customServer);

        var endpoints = _applicationServerInstance.Server.GetEndpoints().Select(e => e.EndpointUrl).Distinct();
        foreach (var endpoint in endpoints)
        {
            logger.LogDebug(endpoint);
        }
    }

    public void Stop()
    {
        customServer?.Stop();
        _applicationServerInstance?.Stop();
    }
}
