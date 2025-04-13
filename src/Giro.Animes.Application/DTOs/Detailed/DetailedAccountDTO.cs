using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Application.DTOs.Simple;
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
        public SimpleSettingsDTO Settings { get; private set; }

        /// <summary>
        /// Status da conta do usuário
        /// </summary>
        public EnumDTO<AccountStatus> Status { get; private set; }

        /// <summary>
        /// Identificador do usuário
        /// </summary>
        public SimpleUserDTO User { get; private set; }

        /// <summary>
        /// Construtor privado para garantir a construção pelo método fábrica Create
        /// </summary>
        /// <param name="id"></param>
        /// <param name="email"></param>
        /// <param name="settings"></param>
        /// <param name="status"></param>
        /// <param name="user"></param>
        /// <param name="creationDate"></param>
        /// <param name="updateDate"></param>
        private DetailedAccountDTO(long id, string email, SimpleSettingsDTO settings, EnumDTO<AccountStatus> status, SimpleUserDTO user, DateTime creationDate, DateTime updateDate) :
            base(id, creationDate, updateDate)
        {
            Email = email;
            Settings = settings;
            Status = status;
            User = user;
        }

        /// <summary>
        /// Método fábrica para criar uma instância de DetailedAccountDTO 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="email"></param>
        /// <param name="settings"></param>
        /// <param name="status"></param>
        /// <param name="user"></param>
        /// <param name="creationDate"></param>
        /// <param name="updateDate"></param>
        /// <returns></returns>
        public static DetailedAccountDTO Create(long id, string email, SimpleSettingsDTO settings, EnumDTO<AccountStatus> status, SimpleUserDTO user, DateTime creationDate, DateTime updateDate)
        {
            return new DetailedAccountDTO(id, email, settings, status, user, creationDate, updateDate);
        }
    }
}
