using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.DTOs
{
    public class BiographyDTO : DescriptionDTO
    {

        /// <summary>
        /// Identificador do autor ao qual a biografia pertence
        /// </summary>
        public long AuthorId { get; private set; }

        private BiographyDTO(long? id, DateTime creationDate, DateTime updateDate, long authorId, string text, LanguageDTO language) :
            base(id, creationDate, updateDate, text, language)
        {
            AuthorId = authorId;
        }
        public static BiographyDTO Create(long? id, DateTime creationDate, DateTime updateDate, long authorId, string text, LanguageDTO language)
        {
            return new BiographyDTO(id, creationDate, updateDate, authorId, text, language);
        }
    }
}
