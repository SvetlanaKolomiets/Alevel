using Homework10.Repositories;
using Homework10.Repositories.Abstractions;
using Homework10.Services;
using Homework10.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Homework10;

class Program
{
    static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection()
            .AddTransient<IElectricalApplianceService, ElectricalApplianceService>()
            .AddTransient<IPluggingInIntoASocketService, PluggingInAppliancesService>()
            .AddScoped<IElectricalAppliancesRepository, ElectricalAppliancesRepository>()
            .AddTransient<Startup>();


        var provider = serviceCollection.BuildServiceProvider();

        var app = provider.GetService<Startup>();
        app!.Run();
    }
}

