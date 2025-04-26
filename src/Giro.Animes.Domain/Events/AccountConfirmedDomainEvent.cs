using Giro.Animes.Domain.Interfaces.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Events
{
    /// <summary>
    /// Evento de domínio que representa a confirmação de uma conta.
    /// </summary>
    public class AccountConfirmedDomainEvent : IDomainEvent
    {
        /// <summary>
        /// Nome de usuário do usuário. Necessário para enviar o template de confirmação de e-mail.
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// Email do usuário. Necessário para enviar o template de confirmação de e-mail.
        /// </summary>
        public string Email { get; private set; }

        public long LanguageId { get; private set; }

        /// <summary>
        /// Construtor privado para evitar a criação de instâncias fora da classe.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        private AccountConfirmedDomainEvent(string username, string email, long languageId)
        {
            Username = username;
            Email = email;
            LanguageId = languageId;
        }

        /// <summary>
        /// Cria uma instância do evento de domínio AccountConfirmedDomainEvent.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public static AccountConfirmedDomainEvent Create(string username, string email, long languageId)
        {
            return new AccountConfirmedDomainEvent(username, email, languageId);
        }
    }
}
