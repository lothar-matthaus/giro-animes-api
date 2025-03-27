using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.DTOs
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade Media.
    /// </summary>
    public abstract class MediaDTO<TMedia> : BaseDTO<TMedia> where TMedia : Media
    {
        /// <summary>
        /// URL da mídia.
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// Nome do arquivo da mídia.
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// Extensão do arquivo da mídia.
        /// </summary>
        public string Extension { get; private set; }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create.
        /// </summary>
        /// <param name="media">Instância da entidade Media.</param>
        protected MediaDTO(TMedia media) : base(media)
        {
            Url = media.Url;
            FileName = media.FileName;
            Extension = media.Extension;
        }
    }
}
