using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Homework17.Services;
using Homework17.Config;
using Homework17.Services.Abstractions;

namespace Homework17;

class Program
{
    static async Task Main(string[] args)
    {
        void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddOptions<LoggerOption>().Bind(configuration.GetSection("Logger"));
            serviceCollection.AddOptions<BackupOption>().Bind(configuration.GetSection("Backup"));

            serviceCollection.AddTransient<IBackupService, BackupService>()
                .AddTransient<ILoggerService, LoggerService>()
                .AddTransient<LoggerOption>()
                .AddTransient<BackupOption>()
                .AddTransient<App>();
        }

        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("config.json")
            .Build();

        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection, configuration);
        var provider = serviceCollection.BuildServiceProvider();

        var app = provider.GetService<App>();

        await app!.Run();
        Console.ReadLine();
    }
}

