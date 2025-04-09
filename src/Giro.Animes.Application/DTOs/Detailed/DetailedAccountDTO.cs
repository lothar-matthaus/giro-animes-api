using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Domain.Enums;

namespace Giro.Animes.Application.DTOs.Detailed
{
    public class DetailedAccountDTO : BaseDTO
    {
        /// <summary>
        /// E-mail da conta
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Configurações da conta do usuário
        /// </summary>
        public DetailedSettingsDTO Settings { get; private set; }

        /// <summary>
        /// Status da conta do usuário
        /// </summary>
        public EnumDTO<AccountStatus> Status { get; private set; }

        /// <summary>
        /// Identificador do usuário
        /// </summary>
        public DetailedUserDTO User { get; private set; }

        private DetailedAccountDTO(DetailedUserDTO user, string email, DetailedSettingsDTO settings, EnumDTO<AccountStatus> status, long? id, DateTime creationDate, DateTime updateDate)
            : base(id, creationDate, updateDate)
        {
            Email = email;
            Settings = settings;
            User = user;
            Status = status;
        }

        public static DetailedAccountDTO Create(DetailedUserDTO user, string email, DetailedSettingsDTO settings, EnumDTO<AccountStatus> status, long? id, DateTime creationDate, DateTime updateDate)
        {
            return new DetailedAccountDTO(user, email, settings, status, id, creationDate, updateDate);
        }
    }
}
