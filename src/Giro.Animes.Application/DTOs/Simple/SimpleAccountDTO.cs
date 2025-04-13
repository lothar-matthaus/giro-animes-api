using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.DTOs.Simple
{
    public class SimpleAccountDTO : BaseSimpleDTO
    {
        /// <summary>
        /// Email atrelado a conta
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Configurações da conta
        /// </summary>
        public SimpleSettingsDTO Settings { get; private set; }

        /// <summary>
        /// Status da conta
        /// </summary>
        public EnumDTO<AccountStatus> Status { get; private set; }

        /// <summary>
        /// Usuário atrelado a conta
        /// </summary>
        public SimpleUserDTO User { get; private set; }

        /// <summary>
        /// Contrutor privado com parâmetros. Garante a construção do objeto através do método Create.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="email"></param>
        /// <param name="settings"></param>
        /// <param name="status"></param>
        /// <param name="id"></param>
        /// <param name="creationDate"></param>
        /// <param name="updateDate"></param>
        private SimpleAccountDTO(SimpleUserDTO user, string email, SimpleSettingsDTO settings, EnumDTO<AccountStatus> status, long? id)
            : base(id)
        {
            Email = email;
            Settings = settings;
            User = user;
            Status = status;
        }

        /// <summary>
        /// Método fábrica para criar instâncias de SimpleAccountDTO.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="email"></param>
        /// <param name="settings"></param>
        /// <param name="status"></param>
        /// <param name="id"></param>
        /// <param name="creationDate"></param>
        /// <param name="updateDate"></param>
        /// <returns></returns>
        public static SimpleAccountDTO Create(SimpleUserDTO user, string email, SimpleSettingsDTO settings, EnumDTO<AccountStatus> status, long? id)
        {
            return new SimpleAccountDTO(user, email, settings, status, id);
        }
    }
}
