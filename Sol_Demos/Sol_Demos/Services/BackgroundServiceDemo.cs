namespace Sol_Demos.Services;

public class BackgroundServiceDemo : BackgroundService
{
    private readonly ILogger<BackgroundServiceDemo> _logger;
    private bool _isRunning;

    public BackgroundServiceDemo(ILogger<BackgroundServiceDemo> logger)
    {
        _logger = logger;
        _isRunning = true;
    }

    public Task StartService()
    {
        _isRunning = true;
        return Task.CompletedTask;
    }

    public Task StopService()
    {
        _isRunning = false;
        return Task.CompletedTask;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_isRunning)
            {
                _logger.LogInformation("Background service is running.");
                // Your background task logic here
            }
            await Task.Delay(1000, stoppingToken); // Delay for demonstration
        }
    }
}