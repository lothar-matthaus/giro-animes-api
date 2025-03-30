using Giro.Animes.Infra.Interfaces.Configs;
using Microsoft.Extensions.DependencyInjection;

namespace Giro.Animes.Infra.Configs
{
    public static class Configurations
    {
        public static IServiceCollection AddAppConfig(this IServiceCollection services)
        {

            services.AddSingleton<IAppConfig, AppConfig>();

            return services;
        }
    }
}
