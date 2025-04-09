namespace Giro.Animes.Application.DTOs.Detailed
{
    public class DetailedGenreTitleDTO : TitleDTO
    {
        /// <summary>
        /// Identificador a qual o título de gênero pertence.
        /// </summary>
        public long GenreId { get; private set; }

        private DetailedGenreTitleDTO(long? id, DateTime creationDate, DateTime updateDate, long genreId, string name, DetailedLanguageDTO language) :
            base(id, creationDate, updateDate, name, language)
        {
            GenreId = genreId;
        }

        public static DetailedGenreTitleDTO Create(long? id, DateTime creationDate, DateTime updateDate, long genreId, string name, DetailedLanguageDTO language)
            => new DetailedGenreTitleDTO(id, creationDate, updateDate, genreId, name, language);
    }
}