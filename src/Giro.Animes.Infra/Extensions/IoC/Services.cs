using Giro.Animes.Infra.Interfaces.Services;
using Giro.Animes.Infra.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Giro.Animes.Infra.Extensions.IoC
{
    public static class Services
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IFileMediaStorageService, FileMediaStorageService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IEmailService, EmailService>();

            return services;
        }
    }
}
