namespace Giro.Animes.Application.DTOs
{
    public class GenreTitleDTO : TitleDTO
    {
        /// <summary>
        /// Identificador a qual o título de gênero pertence.
        /// </summary>
        public long GenreId { get; private set; }

        private GenreTitleDTO(long? id, DateTime creationDate, DateTime updateDate, long genreId, string name, LanguageDTO language) :
            base(id, creationDate, updateDate, name, language)
        {
            GenreId = genreId;
        }

        public static GenreTitleDTO Create(long? id, DateTime creationDate, DateTime updateDate, long genreId, string name, LanguageDTO language)
            => new GenreTitleDTO(id, creationDate, updateDate, genreId, name, language);
    }
}