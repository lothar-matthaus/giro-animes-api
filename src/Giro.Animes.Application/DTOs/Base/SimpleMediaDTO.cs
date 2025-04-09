using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.DTOs.Base
{
    public abstract class SimpleMediaDTO : BaseSimpleDTO
    {
        /// <summary>
        /// URL do arquivo de mídia.
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="id"></param>
        protected SimpleMediaDTO(string url, long? id)
            : base(id)
        {
            Url = url;
        }
    }
}
