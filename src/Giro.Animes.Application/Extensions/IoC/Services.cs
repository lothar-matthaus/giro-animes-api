using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Application.Services;
using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Giro.Animes.Application.Extensions.IoC
{
    public static class Services
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();
        }

        public static void ConfigureDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorDomainService, AuthorDomainService>();
        }
    }
}
