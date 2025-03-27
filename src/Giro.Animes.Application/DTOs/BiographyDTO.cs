using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.DTOs
{
    public class BiographyDTO : DescriptionDTO<Biography>
    {
        /// <summary>
        /// Identificador do autor ao qual a biografia pertence
        /// </summary>
        public long AuthorId { get; private set; }

        private BiographyDTO(Biography biography) : base(biography)
        {
            AuthorId = biography.AuthorId;
        }

        /// <summary>
        /// Cria uma nova instância de BiographyDTO a partir de uma entidade Biography.
        /// </summary>
        /// <param name="biography">A entidade Biography.</param>
        /// <returns>Uma nova instância de BiographyDTO.</returns>
        public static BiographyDTO Create(Biography biography)
        {
            return new BiographyDTO(biography);
        }
    }
}
