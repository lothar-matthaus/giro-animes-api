using Giro.Animes.Infra.Configs;
using Giro.Animes.Infra.Interfaces.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Giro.Animes.Infra.Extensions
{
    public static class Configurations
    {
        public static IServiceCollection AddAppConfig(this IServiceCollection services)
        {

            services.AddSingleton<IApiInfo, ApiInfo>((options) =>
            {
                Assembly assembly = Assembly.GetCallingAssembly();
                IConfiguration configuration = options.GetRequiredService<IConfiguration>();

                return new ApiInfo(configuration, assembly);
            });
            services.AddSingleton<IJwtSettings, JwtSettings>();
            services.AddSingleton<IDataBaseConfig, DataBaseConfig>();
            services.AddSingleton<IMediaConfig, MediaConfig>();
            services.AddSingleton<ICookieConfig, CookieConfig>();
            services.AddSingleton<ISmtpConfig, SmtpConfig>();

            return services;
        }
    }
}
