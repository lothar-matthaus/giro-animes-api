using Giro.Animes.Domain.Interfaces.Events;
namespace Giro.Animes.Domain.Interfaces.DomainEvents.Base
{
    public interface IDomainEventHandler<TDomainEvent> where TDomainEvent : IDomainEvent
    {
        Task HandleAsync(TDomainEvent domainEvent);
    }
}
