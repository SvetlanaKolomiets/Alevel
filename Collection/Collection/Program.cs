namespace Collection;
using Collection.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Collection.Services;
using Collection.Services.Abstractions;
using Collection.Repositories;

class Program
{
    static void Main(string[] args)
    {
        void ConfigureServices(ServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<IOrderService, OrderService>()
                .AddScoped<IOrderRepository, OrderRepository>()
                .AddScoped<Startup>();
        }

        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);


        var provider = serviceCollection.BuildServiceProvider();

        var startup = provider.GetService<Startup>();
        startup.Start();
    }

}
