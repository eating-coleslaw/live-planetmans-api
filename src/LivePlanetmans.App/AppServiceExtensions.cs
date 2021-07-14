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

            var serviceKey = configuration["DaybreakGamesServiceKey"];

            Console.WriteLine($"Service Key: {serviceKey}");

            services.AddCensusServices(options =>
                options.CensusServiceId = serviceKey);
                //options.CensusServiceId = Environment.GetEnvironmentVariable("DaybreakGamesServiceKey", EnvironmentVariableTarget.User));

            services.AddCensusHelpers();
            services.AddCensusStoreServices();
            services.AddCensusStores(configuration);
            services.AddCensusStreamServices(configuration);

            return services;
        }
    }
}
