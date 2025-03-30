using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories.Read;
using Giro.Animes.Domain.Interfaces.Repositories.Read.Base;
using Giro.Animes.Domain.Interfaces.Repositories.Write;
using Giro.Animes.Infra.Data.Contexts;
using Giro.Animes.Infra.Data.Repositories.Read;
using Giro.Animes.Infra.Data.Repositories.Write;
using Microsoft.Extensions.DependencyInjection;

namespace Giro.Animes.Infra.Data.Extensions.IoC
{
    public static class Repositories
    {
        public static void AddReadRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IAuthorReadRepository, AuthorReadRepository>();
            services.AddScoped<ILanguageReadRepository, LanguageReadRepository>();
            services.AddScoped<IMediaReadRepository<Avatar>, MediaReadRepository<Avatar, GiroAnimesReadDbContext>>();
        }

        public static void AddWriteRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<ILanguageWriteRepository, LanguageWriteRepository>();
            services.AddScoped<IAuthorWriteRepository, AuthorWriteRepository>();
            services.AddScoped<IMediaWriteRepository<Avatar>, MediaWriteRepository<Avatar, GiroAnimesWriteDbContext>>();
        }
    }
}
