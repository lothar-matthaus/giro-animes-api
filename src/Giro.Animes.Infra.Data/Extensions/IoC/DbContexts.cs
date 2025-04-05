using Giro.Animes.Infra.Data.Contexts;
using Giro.Animes.Infra.Interfaces.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Giro.Animes.Infra.Data.Extensions.IoC
{
    public static class DbContexts
    {
        public static IServiceCollection AddGiroAnimesDbContext(this IServiceCollection services)
        {
            services.AddDbContext<GiroAnimesDbContext>((serviceProvider, options) =>
            {
                IAppConfig appConfig = serviceProvider.GetRequiredService<IAppConfig>();

                options
                .UseNpgsql(appConfig.DataBaseConfig.ConnectionString)
                .EnableSensitiveDataLogging(appConfig.DataBaseConfig.EnableSensitiveDataLogging)
                .LogTo(Console.WriteLine, appConfig.DataBaseConfig.LogLevel);
            });

            return services;
        }
    }
}
