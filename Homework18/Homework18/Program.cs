﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Homework18.Services.Abstractions;
using Homework18.Services;
using Homework18.Config;

namespace Homework18;

class Program
{
    static async Task Main(string[] args)
    {
        void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddOptions<ApiOption>().Bind(configuration.GetSection("Api"));
            serviceCollection
                .AddLogging(configure => configure.AddConsole())
                .AddHttpClient()
                .AddTransient<IInternalHttpClientService, InternalHttpClientService>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<App>();
        }

        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("config.json")
            .Build();

        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection, configuration);
        var provider = serviceCollection.BuildServiceProvider();

        var app = provider.GetService<App>();
        await app!.Start();
    }
}

