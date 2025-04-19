using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.Interfaces.DomainEvents.Dispatcher;
using Giro.Animes.Domain.Interfaces.Events;
using Giro.Animes.Infra.Data.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Shared.Middlewares
{
    public class DomainEventsHandlingMiddleware : IMiddleware
    {
        private readonly IDomainEventDispatcher _domainEventDispatcher;
        private readonly GiroAnimesDbContext _dbContext;

        public DomainEventsHandlingMiddleware(IDomainEventDispatcher domainEventDispatcher, GiroAnimesDbContext dbContext)
        {
            _domainEventDispatcher = domainEventDispatcher;
            _dbContext = dbContext;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // Executa o próximo middleware no pipeline
            await next(context);

            // Obtém os eventos de domínio das entidades rastreadas pelo ChangeTracker
            var domainEvents = _dbContext.ChangeTracker
                .Entries()
                .Where(entry => entry.Entity is EntityBase entity && entity.DomainEvents != null)
                .SelectMany(entry => ((EntityBase)entry.Entity).DomainEvents)
                .ToList();

            // Verifica se há eventos de domínio antes de despachá-los
            if (domainEvents.Any())
            {
                await _domainEventDispatcher.DispatchAsync(domainEvents);
            }
        }
    }
}
