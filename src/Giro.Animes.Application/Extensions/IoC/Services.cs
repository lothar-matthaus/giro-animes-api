using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Application.Services;
using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories.Base;
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
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<INotificationService, NotificationService>();
        }

        public static void ConfigureDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorDomainService, AuthorDomainService>();
            services.AddScoped<IUserDomainService, UserDomainService>();
            services.AddScoped<ILanguageDomainService, LanguageDomainService>();
            services.AddScoped<IMediaDomainService<Avatar>, MediaDomainService<IMediaRepository<Avatar>, Avatar>>();
        }
    }
}
