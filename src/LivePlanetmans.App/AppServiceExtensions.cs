using LivePlanetmans.App.CensusStream;
using LivePlanetmans.App.Services.Planetside;
using LivePlanetmans.CensusServices;
using LivePlanetmans.CensusStore;
using LivePlanetmans.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LivePlanetmans.App
{
    public static class AppServiceExtensions
    {
        public static IServiceCollection ConfigureAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkContext(configuration);

            Console.WriteLine($"Service Key: {configuration["DaybreakGamesServiceKey"]}");

            services.AddCensusServices(options =>
                options.CensusServiceId = configuration["DaybreakGamesServiceKey"]);
                //options.CensusServiceId = Environment.GetEnvironmentVariable("DaybreakGamesServiceKey", EnvironmentVariableTarget.User));

            services.AddCensusHelpers();
            services.AddCensusStoreServices();
            services.AddCensusStores(configuration);
            services.AddCensusStreamServices(configuration);

            return services;
        }
    }
}
