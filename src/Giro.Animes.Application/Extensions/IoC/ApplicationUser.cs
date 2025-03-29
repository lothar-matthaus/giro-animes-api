using Giro.Animes.Infra.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Giro.Animes.Application.Extensions.IoC
{
    public static class ApplicationUser
    {
        public static IServiceCollection AddApplicationUser(this IServiceCollection services)
        {
            services.AddScoped<IApplicationUser, Infra.ApplicationUser>();
            return services;
        }
    }
}
