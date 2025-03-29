using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.DTOs
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade Title.
    /// </summary>
    public abstract class TitleDTO : BaseDTO
    {
        /// <summary>
        /// Nome do título.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Idioma do título.
        /// </summary>
        public LanguageDTO Language { get; private set; }

        protected TitleDTO(long? id, DateTime creationDate, DateTime updateDate, string name, LanguageDTO language) :
            base(id, creationDate, updateDate)
        {
            Name = name;
            Language = language;
        }
    }
}
