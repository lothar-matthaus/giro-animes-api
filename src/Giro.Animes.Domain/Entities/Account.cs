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

        /// <summary>
        /// Configurações da conta do usuário
        /// </summary>
        public Settings Settings { get; private set; }

        /// <summary>
        /// Indica se a conta foi confirmada
        /// </summary>
        public bool IsConfirmed { get; private set; } = false;

        /// <summary>
        /// Usuário atrelado a conta 
        /// </summary>
        public User User { get; private set; }

        /// <summary>
        /// Construtor padrão
        /// </summary>
        public Account()
        {
        }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        private Account(User user, Email email, Password password, Settings settings)
        {
            Email = email;
            Password = password;
            Status = AccountStatus.Active;
            Settings = settings;
            User = user;
        }

        /// <summary>
        /// Cria uma instância de Account. Utilize este método para garantir a construção do objeto
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="user"> </param>
        /// <returns></returns>
        public static Account Create(User user, Email email, Password password, Settings settings) => new Account(user, email, password, settings);

        #region Behaviors
        public void TryChangeEmail(Email email)
        {
            if (email.IsValid)
                Email = email;
        }

        public void TryChangePassword(Password password)
        {
            if (password.IsValid)
                Password = password;
        }

        internal void TryChangeSettings(Settings settings)
        {
            if (settings.IsValid)
                Settings = settings;
        }

        #endregion
    }
}
