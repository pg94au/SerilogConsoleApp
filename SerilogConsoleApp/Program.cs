using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace SerilogConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
        configurationBuilder.AddJsonFile("appsettings.json", false, true);
        var configuration = configurationBuilder.Build();

        var serviceCollection = new ServiceCollection();
        serviceCollection.AddLogging(builder =>
        {
            var logger = new LoggerConfiguration().Enrich.FromLogContext().ReadFrom.Configuration(configuration).CreateLogger();
            builder.AddSerilog(logger);
        });
        serviceCollection.AddSingleton<Service>();
        serviceCollection.AddSingleton<Widget>();
        var serviceProvider = serviceCollection.BuildServiceProvider();

        var logger = serviceProvider.GetService<ILogger<Program>>()!;
        logger.LogInformation("Program running as information.");
        logger.LogWarning("Program is running as warning.");

        var service = serviceProvider.GetRequiredService<Service>();
        service.Run();

        Log.CloseAndFlush();
    }
}
