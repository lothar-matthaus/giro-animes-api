using Giro.Animes.Application.DTOs.Detailed;

namespace Giro.Animes.Application.DTOs.Base
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade Description.
    /// </summary>
    public abstract class DescriptionDTO : BaseDTO
    {
        /// <summary>
        /// Texto da descrição.
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Idioma da descrição.
        /// </summary>
        public DetailedLanguageDTO Language { get; private set; }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create.
        /// </summary>
        /// <param name="description">Instância da entidade Description.</param>
        protected DescriptionDTO(long? id, DateTime creationDate, DateTime updateDate, string text, DetailedLanguageDTO language) :
            base(id, creationDate, updateDate)
        {
            Text = text;
            Language = language;
        }
    }
}
