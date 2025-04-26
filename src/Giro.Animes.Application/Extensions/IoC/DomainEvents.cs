using Giro.Animes.Application.Events.Dispatcher;
using Giro.Animes.Application.Events.Handlers.Base;
using Giro.Animes.Domain.Interfaces.DomainEvents.Base;
using Giro.Animes.Domain.Interfaces.DomainEvents.Dispatcher;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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
                .Where(t => t.IsClass && !t.IsAbstract && t.BaseType != null &&
                            t.BaseType.IsGenericType &&
                            t.BaseType.GetGenericTypeDefinition() == typeof(DomainEventHandlerBase<>))
                .ToList();

            foreach (Type handler in handlers)
            {
                Type interfaceType = handler.GetInterfaces()
                    .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDomainEventHandler<>));
                if (interfaceType != null)
                {
                    services.AddScoped(interfaceType, handler);
                }
            }

            return services;
        }
    }
}
