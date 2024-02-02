using Homework10.Config;
using Homework10.Repositories;
using Homework10.Repositories.Abstractions;
using Homework10.Services;
using Homework10.Services.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Homework10;

class Program
{
    static void Main(string[] args)
    {
        void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddOptions<LoggerOption>().Bind(configuration.GetSection("Logger"));

            serviceCollection.AddTransient<IElectricalApplianceService, ElectricalApplianceService>()
            .AddTransient<IPluggingInIntoASocketService, PluggingInAppliancesService>()
            .AddScoped<IElectricalAppliancesRepository, ElectricalAppliancesRepository>()
            .AddSingleton<ILoggerService, LoggerService>()
            .AddTransient<Startup>();

        }

        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("config.json")
            .Build();

        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection, configuration);
        var provider = serviceCollection.BuildServiceProvider();


        var app = provider.GetService<Startup>();
        app!.Run();
    }
}

