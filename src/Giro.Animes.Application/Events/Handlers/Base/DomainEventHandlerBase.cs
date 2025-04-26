using Giro.Animes.Domain.Interfaces.DomainEvents.Base;
using Giro.Animes.Domain.Interfaces.Events;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.Events.Handlers.Base
{
    public abstract class DomainEventHandlerBase<TDomainEvent> : IDomainEventHandler<TDomainEvent> where TDomainEvent : IDomainEvent
    {
        protected readonly ILogger<TDomainEvent> _logger;

        protected DomainEventHandlerBase(ILogger<TDomainEvent> logger)
        {
            _logger = logger;
        }

        public abstract Task HandleAsync(TDomainEvent domainEvent);
    }
}
