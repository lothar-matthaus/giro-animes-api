using Giro.Animes.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Giro.Animes.Infra.Data.Configurations.IoC
{
    public static class Injection
    {
        public static void AddGiroAnimesDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GiroAnimesDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("GiroAnimesDb"));
            });
        }
    }
}
