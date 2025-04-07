using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Domain.Enums;

namespace Giro.Animes.Application.DTOs
{
    public class AccountDTO : BaseDTO
    {
        /// <summary>
        /// E-mail da conta
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Configurações da conta do usuário
        /// </summary>
        public SettingsDTO Settings { get; private set; }

        /// <summary>
        /// Status da conta do usuário
        /// </summary>
        public EnumDTO<AccountStatus> Status { get; private set; }

        /// <summary>
        /// Identificador do usuário
        /// </summary>
        public UserDTO User { get; private set; }

        private AccountDTO(UserDTO user, string email, SettingsDTO settings, EnumDTO<AccountStatus> status, long? id, DateTime creationDate, DateTime updateDate)
            : base(id, creationDate, updateDate)
        {
            Email = email;
            Settings = settings;
            User = user;
            Status = status;
        }

        public static AccountDTO Create(UserDTO user, string email, SettingsDTO settings, EnumDTO<AccountStatus> status, long? id, DateTime creationDate, DateTime updateDate)
        {
            return new AccountDTO(user, email, settings, status, id, creationDate, updateDate);
        }
    }
}
