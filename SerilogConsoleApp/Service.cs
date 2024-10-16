using Microsoft.Extensions.Logging;

namespace SerilogConsoleApp;

public class Service
{
    private readonly Widget _widget;
    private readonly ILogger _logger;

    public Service(Widget widget, ILogger<Service> logger)
    {
        _widget = widget;
        _logger = logger;
    }

    public void Run()
    {
        using var scope = _logger.BeginScope("Service run scope");
        _logger.LogInformation("Service running as information.");
        _logger.LogWarning("Service running as warning.");

        _widget.Run();
    }
}
