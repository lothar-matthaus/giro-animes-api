using Giro.Animes.Infra.Configs;
using Giro.Animes.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Giro.Animes.Infra.Data.Extensions.IoC
{
    public static class DbContexts
    {
        public static void AddWriteDbContext(this IServiceCollection services)
        {
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            services.AddDbContext<GiroAnimesWriteDbContext>(options =>
            {
                AppConfig config = serviceProvider.GetRequiredService<AppConfig>();
                options.UseNpgsql(config.DataBaseConfig.GiroAnimesDb);
            });
        }
        public static void AddReadDbContext(this IServiceCollection services)
        {
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            services.AddDbContext<GiroAnimesReadDbContext>(options =>
            {
                AppConfig config = serviceProvider.GetRequiredService<AppConfig>();
                options.UseNpgsql(config.DataBaseConfig.GiroAnimesDb);
            });
        }
    }
}
