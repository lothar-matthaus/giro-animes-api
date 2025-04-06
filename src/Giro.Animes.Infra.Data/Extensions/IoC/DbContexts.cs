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
                IDataBaseConfig dataBaseConfig = serviceProvider.GetRequiredService<IDataBaseConfig>();

                options
                .UseNpgsql(dataBaseConfig.ConnectionString)
                .EnableSensitiveDataLogging(dataBaseConfig.EnableSensitiveDataLogging)
                .LogTo(Console.WriteLine, dataBaseConfig.LogLevel);
            });

            return services;
        }
    }
}
