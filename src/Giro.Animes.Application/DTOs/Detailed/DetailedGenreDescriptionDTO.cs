using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.DTOs.Detailed
{
    public class DetailedGenreDescriptionDTO : DescriptionDTO
    {

        /// <summary>
        /// Identificador do gênero a qual a descrição pertence.
        /// </summary>
        public long GenreId { get; private set; }

        private DetailedGenreDescriptionDTO(long? id, DateTime creationDate, DateTime updateDate, long genreId, string text, DetailedLanguageDTO language) : base(id, creationDate, updateDate, text, language)
        {
            GenreId = genreId;
        }
        public static DetailedGenreDescriptionDTO Create(long? id, DateTime creationDate, DateTime updateDate, long genreId, string text, DetailedLanguageDTO language)
            => new DetailedGenreDescriptionDTO(id, creationDate, updateDate, genreId, text, language);
    }
}