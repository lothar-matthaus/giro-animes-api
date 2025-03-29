using Giro.Animes.Domain.Interfaces.Repositories.Read;
using Giro.Animes.Domain.Interfaces.Repositories.Write;
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
        }

        public static void AddWriteRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<IAuthorWriteRepository, AuthorWriteRepository>();
        }
    }
}
