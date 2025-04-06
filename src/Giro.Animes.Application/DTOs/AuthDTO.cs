using Giro.Animes.Application.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.DTOs
{
    public class AuthDTO : BaseDTO
    {
        /// <summary>
        /// Mensagem de retorno
        /// </summary>
        public string UserName { get; private set; }

        public EnumDTO<int> Status { get; private set; }
        /// <summary>
        /// Cria uma nova instância de AuthDTO
        /// </summary>
        /// <param name="message"></param>
        public AuthDTO(string username, EnumDTO<int> status)
        { 
            UserName = username;
            Status = status;
        }

        /// <summary>
        /// Cria uma nova instância de AuthDTO
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static AuthDTO Create(string username, EnumDTO<int> status) => new AuthDTO(username, status);
    }
}
