using Giro.Animes.Infra.Configs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Infra.Extensions.Dependencies
{
    public static class Configurations
    {
        public static void AddAppConfig(this IServiceCollection services)
        {
            services.AddSingleton<AppConfig>();
        }
    }
}
