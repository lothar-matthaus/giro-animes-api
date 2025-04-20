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
        /// <summary>
        /// Nome de usuário do usuário. Necessário para enviar o template de boas-vindas.
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// Email do usuário. Necessário para enviar o template de boas-vindas.
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Idioma associado a interface de usuário. Necessário para enviar o template no idioma correto.
        /// </summary>
        public long LanguageId { get; set; }

        /// <summary>
        /// Construtor privado para evitar a criação de instâncias fora da classe.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="languageId"></param>
        private AccountCreatedDomainEvent(string username, string email, long languageId)
        {
            Username = username;
            Email = email;
            LanguageId = languageId;
        }

        /// <summary>
        /// Cria uma instância do evento de domínio AccountCreatedDomainEvent.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="languageId"></param>
        /// <returns></returns>
        public static AccountCreatedDomainEvent Create(string username, string email, long languageId)
        {
            return new AccountCreatedDomainEvent(username, email, languageId);
        }
    }
}
