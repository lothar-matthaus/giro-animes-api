using Asp.Versioning;
using Giro.Animes.Infra.Configs;
using Giro.Animes.Infra.Interfaces.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Shared.Extensions.Versioning
{
    public static class ApiVersioning
    {
        /// <summary>
        /// Configura o versionamento da API.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddApiVersioningConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApiVersioning(options =>
             {
                 IApiInfo apiInfo = new ApiInfo(configuration);

                 if (apiInfo == null)
                     throw new ArgumentNullException("As informações da API não foram encontradas nas variáveis de ambiente.");

                 options.DefaultApiVersion = new ApiVersion(apiInfo.Version[0], apiInfo.Version[1]);
                 options.AssumeDefaultVersionWhenUnspecified = true;
                 options.ReportApiVersions = true;
             });
            return services;
        }
    }
}
