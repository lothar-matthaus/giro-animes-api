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
        public LanguageDTO Language { get; private set; }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create.
        /// </summary>
        /// <param name="description">Instância da entidade Description.</param>
        protected DescriptionDTO(long? id, DateTime creationDate, DateTime updateDate, DateTime? deletionDate, string text, LanguageDTO language) :
            base(id, creationDate, updateDate, deletionDate)
        {
            Text = text;
            Language = language;
        }
    }
}
