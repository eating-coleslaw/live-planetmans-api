// Credit to Lampjaw

using LivePlanetmans.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace LivePlanetmans.Data
{
    public static class DatabaseExtensions
    {
        private static readonly string _migrationAssembly = typeof(DatabaseExtensions).GetTypeInfo().Assembly.GetName().Name;

        private static readonly object _initializeLock = new();
        private static bool _initialized = false;

        public static IServiceCollection AddEntityFrameworkContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<DatabaseOptions>(configuration);

            var options = configuration.Get<DatabaseOptions>();

            var connectionString = configuration["ConnectionStrings:PlanetmansConnectionString"];

            services.AddDbContextPool<PlanetmansDbContext>(builder =>
                builder.UseNpgsql(connectionString, b =>
                {
                    b.MigrationsAssembly(_migrationAssembly);
                }),
                options.PoolSize);

            services.AddSingleton<IDbContextHelper, DbContextHelper>();
            services.AddSingleton<IUpdaterSchedulerRepository, UpdaterSchedulerRepository>();
            
            services.AddSingleton<IFactionRepository, FactionRepository>();
            services.AddSingleton<IItemRepository, ItemRepository>();
            services.AddSingleton<IZoneRepository, ZoneRepository>();
            services.AddSingleton<IWorldRepository, WorldRepository>();
            services.AddSingleton<IVehicleRepository, VehicleRepository>();
            services.AddSingleton<IProfileRepository, ProfileRepository>();
            services.AddSingleton<ILoadoutRepository, LoadoutRepository>();
            services.AddSingleton<IFacilityRepository, FacilityRepository>();
            services.AddSingleton<IMetagameEventRepository, MetagameEventRepository>();
            services.AddSingleton<IExperienceRepository, ExperienceRepository>();
            services.AddSingleton<IEventRepository, EventRepository>();
            services.AddSingleton<ICharacterRepository, CharacterRepository>();
            //services.AddSingleton<IOutfitRepository, OutfitRepository>();

            return services;
        }

        public static void InitializeDatabase(IServiceProvider serviceProvider)
        {
            if (_initialized)
            {
                return;
            }

            lock (_initializeLock)
            {
                using var context = new PlanetmansDbContext(
                    serviceProvider.GetRequiredService<DbContextOptions<PlanetmansDbContext>>());

                context.Database.Migrate();
            }

            return;
        }

        public static void SeedDatabase(this IApplicationBuilder app)
        {
            if (_initialized)
            {
                return;
            }

            lock (_initializeLock)
            {
                _initialized = true;
            }
        }

        public static IApplicationBuilder InitializePlanetmansDatabase(this IApplicationBuilder app)
        {
            if (_initialized)
            {
                return app;
            }

            lock (_initializeLock)
            {
                using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<PlanetmansDbContext>();

                dbContext.Database.Migrate();
            }

            app.SeedDatabase();

            return app;
        }
    }
}
