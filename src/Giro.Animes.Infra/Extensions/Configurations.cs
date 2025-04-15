using Giro.Animes.Infra.Configs;
using Giro.Animes.Infra.Interfaces.Configs;
using Microsoft.Extensions.DependencyInjection;

namespace Giro.Animes.Infra.Extensions
{
    public static class Configurations
    {
        public static IServiceCollection AddAppConfig(this IServiceCollection services)
        {

            services.AddSingleton<IJwtSettings, JwtSettings>();
            services.AddSingleton<IDataBaseConfig, DataBaseConfig>();
            services.AddSingleton<IMediaConfig, MediaConfig>();
            services.AddSingleton<IApiInfo, ApiInfo>();
            services.AddSingleton<ICookieConfig, CookieConfig>();

            return services;
        }
    }
}
