using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.DTOs.Detailed
{
    public class DetaledBiographyDTO : DescriptionDTO
    {

        /// <summary>
        /// Identificador do autor ao qual a biografia pertence
        /// </summary>
        public long AuthorId { get; private set; }

        private DetaledBiographyDTO(long? id, DateTime creationDate, DateTime updateDate, long authorId, string text, DetailedLanguageDTO language) :
            base(id, creationDate, updateDate, text, language)
        {
            AuthorId = authorId;
        }
        public static DetaledBiographyDTO Create(long? id, DateTime creationDate, DateTime updateDate, long authorId, string text, DetailedLanguageDTO language)
        {
            return new DetaledBiographyDTO(id, creationDate, updateDate, authorId, text, language);
        }
    }
}
