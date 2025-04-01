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
        /// Identificador do plano do usuário 
        /// </summary>
        public AccountPlan Plan { get; private set; }

        /// <summary>
        /// Identificador da imagem de perfil
        /// </summary>
        public Avatar Avatar { get; private set; }

        /// <summary>
        /// Configurações da conta do usuário
        /// </summary>
        public Settings Settings { get; private set; }

        /// <summary>
        /// Lista de favoritos para assistir.
        /// </summary>
        public IEnumerable<Anime> Watchlist { get; private set; }

        /// <summary>
        /// Identificador do usuário
        /// </summary>
        public long UserId { get; private set; }
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
        private Account(Email email, Password password, Settings settings, Avatar avatar = null)
        {
            Email = email;
            Password = password;
            Avatar = avatar;
            Status = AccountStatus.EmailNotConfirmed;
            Plan = AccountPlan.Bronze;
            Settings = settings;
        }

        /// <summary>
        /// Cria uma instância de Account. Utilize este método para garantir a construção do objeto
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static Account Create(Email email, Password password, Settings settings, Avatar avatar = null) => new Account(email, password, settings, avatar);
    }
}
