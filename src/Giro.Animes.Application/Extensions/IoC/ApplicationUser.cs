using Giro.Animes.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.Extensions.IoC
{
    public static class ApplicationUser
    {
        public static void AddApplicationUser(this IServiceCollection services)
        {
            services.AddScoped<IApplicationUser, Application.ApplicationUser>();
        }
    }
}
