using Giro.Animes.Domain.Interfaces.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Events
{
    public record AccountCreatedDomainEvent : IDomainEvent
    {
        public string Username { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountCreatedDomainEvent"/> class.
        /// </summary>
        /// <param name="username"></param>
        private AccountCreatedDomainEvent(string username)
        {
            Username = username;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="AccountCreatedDomainEvent"/> class.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static AccountCreatedDomainEvent Create(string username)
        {
            return new AccountCreatedDomainEvent(username);
        }
    }
}
