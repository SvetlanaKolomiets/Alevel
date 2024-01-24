using Homework9.Services.Abstractions;
using Homework9.Services;
using Homework9.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Homework9;

class Program
{
    static void Main(string[] args)
    {
        void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddOptions<LoggerOption>().Bind(configuration.GetSection("Logger"));

            serviceCollection.AddTransient<IFileService, FileService>()
                .AddSingleton<ILoggerService, LoggerService>()
                .AddTransient<LoggerOption>()
                .AddTransient<Actions>()
                .AddTransient<App>();
        }

        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("config.json")
            .Build();

        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection, configuration);
        var provider = serviceCollection.BuildServiceProvider();


        var app = provider.GetService<App>();

        var fileService = provider.GetService<IFileService>();

        app!.Run();
        fileService!.WriteLogsToAFile();
        Console.ReadLine();
    }
}

