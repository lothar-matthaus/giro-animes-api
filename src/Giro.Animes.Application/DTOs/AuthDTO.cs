using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Domain.Enums;

namespace Giro.Animes.Application.DTOs
{
    public class AuthDTO : BaseDTO
    {
        /// <summary>
        /// Mensagem de retorno
        /// </summary>
        public string UserName { get; private set; }

        public EnumDTO<AccountStatus> Status { get; private set; }
        /// <summary>
        /// Cria uma nova instância de AuthDTO
        /// </summary>
        /// <param name="message"></param>
        public AuthDTO(string username, EnumDTO<AccountStatus> status)
        {
            UserName = username;
            Status = status;
        }

        /// <summary>
        /// Cria uma nova instância de AuthDTO
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static AuthDTO Create(string username, EnumDTO<AccountStatus> status) => new AuthDTO(username, status);
    }
}
