
using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Domain.ValueObjects;

namespace Giro.Animes.Domain.Entities
{
    public class Account : EntityBase
    {
        /// <summary>
        /// E-mail da conta
        /// </summary>
        public Email Email { get; private set; }
        /// <summary>
        /// Senha da conta
        /// </summary>
        public Password Password { get; private set; }
        /// <summary>
        /// Status da conta
        /// </summary>
        public AccountStatus Status { get; private set; }

        public ProfilePicture ProfilePicture { get; private set; }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        private Account(Email email, Password password, ProfilePicture profilePicture)
        {
            Email = email;
            Password = password;
            ProfilePicture = profilePicture;
            Status = AccountStatus.EmailNotConfirmed;
        }

        /// <summary>
        /// Cria uma instância de Account. Utilize este método para garantir a construção do objeto
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static Account Create(Email email, Password password, ProfilePicture profilePicture) => new Account(email, password, profilePicture);
    }
}
