using Homework21.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Homework21;

class Program
{
    static async Task Main(string[] args)
    {
        void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            serviceCollection.AddDbContext<ApplicationDbContext>(opts
                => opts.UseSqlServer(connectionString));

            serviceCollection
                .AddLogging(configure => configure.AddConsole())
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

