using Giro.Animes.Domain.Interfaces.Repositories.Read;
using Giro.Animes.Domain.Interfaces.Repositories.Write;
using Giro.Animes.Infra.Data.Repositories.Read;
using Giro.Animes.Infra.Data.Repositories.Write;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Infra.Data.Extensions.IoC
{
    public static class Repositories
    {
        public static void AddReadRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserReadRepository, UserReadRepository>();
        }

        public static void AddWriteRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
        }
    }
}
