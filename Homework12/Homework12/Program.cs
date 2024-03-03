using Homework12.Repositories;
using Homework12.Repositories.Abstractions;
using Homework12.Services;
using Microsoft.Extensions.DependencyInjection;
using Homework12.Services.Abstractions;

namespace Homework12;

class Program
{
    static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection()
            .AddTransient<IContactsRepository, ContactsRepository>()
            .AddScoped<IContactService, ContactService>()
            .AddTransient<Startup>();


        var provider = serviceCollection.BuildServiceProvider();

        var app = provider.GetService<Startup>();
        app!.Run();
        
    }
}

