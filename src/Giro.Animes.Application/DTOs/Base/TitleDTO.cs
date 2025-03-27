using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.DTOs
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade Title.
    /// </summary>
    public abstract class TitleDTO<TTitle> : BaseDTO<Title>  where TTitle : Title
    {
        /// <summary>
        /// Nome do título.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Identificador do idioma do título.
        /// </summary>
        public long LanguageId { get; private set; }

        /// <summary>
        /// Idioma do título.
        /// </summary>
        public LanguageDTO Language { get; private set; }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create.
        /// </summary>
        /// <param name="title">Instância da entidade Title.</param>
        protected TitleDTO(TTitle title) : base(title)
        {
            Name = title.Name;
            LanguageId = title.LanguageId;
            Language = LanguageDTO.Create(title.Language);
        }
    }
}
