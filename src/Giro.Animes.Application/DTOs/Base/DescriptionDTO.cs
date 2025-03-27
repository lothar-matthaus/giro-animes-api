using Giro.Animes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.DTOs.Base
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade Description.
    /// </summary>
    public abstract class DescriptionDTO<TDescription> : BaseDTO<Description> where TDescription : Description
    {
        /// <summary>
        /// Texto da descrição.
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Identificador do idioma da descrição.
        /// </summary>
        public long? LanguageId { get; private set; }

        /// <summary>
        /// Idioma da descrição.
        /// </summary>
        public LanguageDTO Language { get; private set; }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create.
        /// </summary>
        /// <param name="description">Instância da entidade Description.</param>
        protected DescriptionDTO(TDescription description) : base(description)
        {
            Text = description.Text;
            LanguageId = description.LanguageId;
            Language = LanguageDTO.Create(description.Language);
        }
    }
}
