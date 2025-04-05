using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories;
using Giro.Animes.Domain.Interfaces.Repositories.Base;
using Giro.Animes.Infra.Data.Contexts;
using Giro.Animes.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Giro.Animes.Infra.Data.Extensions.IoC
{
    public static class Repositories
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IMediaRepository<Avatar>, MediaRepository<Avatar, GiroAnimesDbContext>>();
        }
    }
}
