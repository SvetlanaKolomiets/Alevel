using Homework8.Repositories;
using Homework8.Repositories.Abstractions;
using Homework8.Services;
using Homework8.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
namespace Homework8;

class Program
{
    static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection()
            .AddTransient<IVegetableService, VegetableService>()
            .AddScoped<IVegetablesRepository, VegetablesRepository>()
            .AddTransient<ISaladService, SaladService>()
            .AddTransient<Startup>();

        
        var provider = serviceCollection.BuildServiceProvider();

        var app = provider.GetService<Startup>();
        app!.Run();
    }
}

