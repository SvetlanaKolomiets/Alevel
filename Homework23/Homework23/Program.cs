using Homework23.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Homework23.Services;
using Homework23.Services.Abstractions;
using Homework23.Repositories.Abstractions;
using Homework23.Repositories;

namespace Homework23;

class Program
{
    static async Task Main(string[] args)
    {
        void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            serviceCollection.AddDbContextFactory<ApplicationDbContext>(opts
                => opts.UseSqlServer(connectionString));
            serviceCollection.AddScoped<IDbContextWrapper<ApplicationDbContext>, DbContextWrapper<ApplicationDbContext>>();

            serviceCollection
                .AddLogging(configure => configure.AddConsole())
                .AddTransient<IBreedRepository, BreedRepository>()
                .AddTransient<ICategoryRepository, СategoryRepository>()
                .AddTransient<ILocationRepository, LocationRepository>()
                .AddTransient<IPetRepository, PetRepository>()
                .AddTransient<IBreedService, BreedService>()
                .AddTransient<ICategoryService, CategoryService>()
                .AddTransient<ILocationService, LocationService>()
                .AddTransient<IPetService, PetService>()
                .AddTransient<App>();
        }

        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("config.json")
            .Build();

        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection, configuration);
        var provider = serviceCollection.BuildServiceProvider();

        var migrationSection = configuration.GetSection("Migration");
        var isNeedMigration = migrationSection.GetSection("IsNeedMigration");

        if (bool.Parse(isNeedMigration.Value))
        {
            var dbContext = provider.GetService<ApplicationDbContext>();
            await dbContext!.Database.MigrateAsync();
        }

        var app = provider.GetService<App>();
        await app!.Start();
    }
}

