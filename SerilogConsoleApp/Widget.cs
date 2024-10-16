using Microsoft.Extensions.Logging;

namespace SerilogConsoleApp
;
public class Widget
{
    private readonly ILogger _logger;

    public Widget(ILogger<Widget> logger)
    {
        _logger = logger;
    }

    public void Run()
    {
        using var scope = _logger.BeginScope("Widget run scope");
        _logger.LogInformation("Widget running as information.");
        _logger.LogWarning("Widget running as warning.");
    }
}