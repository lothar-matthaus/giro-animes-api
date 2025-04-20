using Giro.Animes.Domain.Events.Dispatcher;
using Giro.Animes.Domain.Interfaces.DomainEvents.Base;
using Giro.Animes.Domain.Interfaces.DomainEvents.Dispatcher;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.Extensions.IoC
{
    public static class DomainEvents
    {
        public static IServiceCollection AddDomainEvents(this IServiceCollection services)
        {
            // Registra o serviço de despacho de eventos de domínio
            services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

            // Registra todos os manipuladores de eventos de domínio
            Assembly assembly = AppDomain.CurrentDomain.Load("Giro.Animes.Application");
            IEnumerable<Type> handlers = assembly.GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDomainEventHandler<>)))
                .ToList();

            foreach (Type handler in handlers)
            {
                services.AddScoped(handler.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDomainEventHandler<>)), handler);
            }

            return services;
        }
    }
}
