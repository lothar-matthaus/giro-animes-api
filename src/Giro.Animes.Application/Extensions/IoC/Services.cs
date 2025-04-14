using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Application.Services;
using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories.Base;
using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.Serialization;

namespace Giro.Animes.Application.Extensions.IoC
{
    public static class Services
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IAnimeService, AnimeService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }

        public static IServiceCollection ConfigureDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorDomainService, AuthorDomainService>();
            services.AddScoped<IAccountDomainService, AccountDomainService>();
            services.AddScoped<ILanguageDomainService, LanguageDomainService>();
            services.AddScoped<IAnimeDomainService, AnimeDomainService>();
            services.AddScoped<IMediaDomainService<Avatar>, MediaDomainService<IMediaRepository<Avatar>, Avatar>>();
            services.AddScoped<IPermissionDomainService, PermissionDomainService>();

            return services;
        }
    }
}
