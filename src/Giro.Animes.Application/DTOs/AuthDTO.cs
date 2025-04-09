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

        public EnumDTO<UserRole> Role { get; private set; }
        /// <summary>
        /// Cria uma nova instância de AuthDTO
        /// </summary>
        /// <param name="message"></param>

        public AuthDTO(string username, EnumDTO<UserRole> role, long id) : base(id, DateTime.Now, DateTime.Now)
        {
            UserName = username;
            Role = role;
        }

        /// <summary>
        /// Cria uma nova instância de AuthDTO
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static AuthDTO Create(string username, EnumDTO<UserRole> role, long id) => new AuthDTO(username, role, id);
    }
}
