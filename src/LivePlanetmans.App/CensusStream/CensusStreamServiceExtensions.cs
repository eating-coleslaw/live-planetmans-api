using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LivePlanetmans.App.CensusStream.EventProcessors;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LivePlanetmans.App.CensusStream
{
    public static class CensusStreamServiceExtensions
    {
        public static IServiceCollection AddCensusStreamServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();

            services.Configure<CensusStreamOptions>(configuration);

            services.Configure<CensusStreamOptions>(options =>
            {
                var streamOptions = configuration.GetSection("CensusStreamOptions");

                options.CensusStreamCharacters = streamOptions.GetValue<IEnumerable<string>>("Characters");
                options.CensusStreamWorlds = streamOptions.GetValue<IEnumerable<string>>("Worlds");
                options.CensusStreamServices = streamOptions.GetValue<IEnumerable<string>>("Services");
                options.CensusStreamLogicalAndCharactersWithWorlds = streamOptions.GetValue<bool>("LogicalAndCharactersWithWorlds");

                var experienceIds = streamOptions.GetValue<IEnumerable<string>>("ExperienceIds");

                if (experienceIds != null)
                {
                    options.CensusStreamExperienceIds = experienceIds;
                }
            });


            services.AddTransient<IWebsocketEventHandler, WebsocketEventHandler>();
            
            // Option 1: Use this if you only need one WebsocketMonitor instance
            services.AddTransient<IWebsocketMonitor, WebsocketMonitor>();
            services.AddHostedService<WebsocketMonitorHostedService>();

            // Option 2: Use these insteand of the above if you are using multiple WebsocketMonitor instances via WebsocketMonitorHealper
            /*
                services.AddTransient<WebsocketMonitor>();
                services.AddSingleton<IWebsocketMonitorHelper, WebsocketMonitorHelper>();
            */


            services.AddTransient<IWebsocketHealthMonitor, WebsocketHealthMonitor>();

            services.AddEventProcessors();

            services.AddSingleton<IEventProcessorHandler, EventProcessorHandler>();


            return services;
        }

        // Credit to Lampjaw
        private static void AddEventProcessors(this IServiceCollection services)
        {
            var iType = typeof(IEventProcessor<>);
            var types = iType.GetTypeInfo().Assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .SelectMany(t => t.GetInterfaces().Select(i => (t, i)))
                .Where(a => a.i.IsGenericType && iType.IsAssignableFrom(a.i.GetGenericTypeDefinition()))
                .ToList();

            types.ForEach(a => services.AddSingleton(a.i, a.t));
        }
    }
}
