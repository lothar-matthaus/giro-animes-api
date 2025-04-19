using Giro.Animes.Domain.Interfaces.DomainEvents.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Events.Handlers
{
    public class AccountCreatedDomainEventHandler : IDomainEventHandler<AccountCreatedDomainEvent>
    {
        public Task HandleAsync(AccountCreatedDomainEvent domainEvent)
        {
            Console.WriteLine($"Account created: {domainEvent.Username}");
            Console.WriteLine("Enviado e-mail de boas vindas...");

            return Task.CompletedTask;
        }
    }
}
