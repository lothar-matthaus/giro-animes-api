using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.DTOs
{
    public class GenreDescriptionDTO : DescriptionDTO
    {

        /// <summary>
        /// Identificador do gênero a qual a descrição pertence.
        /// </summary>
        public long GenreId { get; private set; }

        private GenreDescriptionDTO(long? id, DateTime creationDate, DateTime updateDate, long genreId, string text, LanguageDTO language) : base(id, creationDate, updateDate, text, language)
        {
            GenreId = genreId;
        }
        public static GenreDescriptionDTO Create(long? id, DateTime creationDate, DateTime updateDate, long genreId, string text, LanguageDTO language)
            => new GenreDescriptionDTO(id, creationDate, updateDate, genreId, text, language);
    }
}