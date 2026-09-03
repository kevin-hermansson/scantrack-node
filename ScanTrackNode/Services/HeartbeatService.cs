namespace ScanTrackNode.Services;

public class HeartbeatService : BackgroundService
{
    private readonly NodeRegistry _registry;
    private readonly ILogger<HeartbeatService> _logger;

    public HeartbeatService(
        NodeRegistry registry,
        ILogger<HeartbeatService> logger)
    {
        _registry = registry;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromHours(1), stoppingToken);

            _logger.LogInformation("Skickar heartbeat till registret nu");

            await _registry.RegisterSelfAsync();
        }
    }
}