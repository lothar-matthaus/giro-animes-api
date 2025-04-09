namespace Giro.Animes.Application.DTOs.Detailed
{
    public class DetailedAnimeTitleDTO : TitleDTO
    {
        /// <summary>
        /// Identificador do anime ao qual o título pertence
        /// </summary>
        public long AnimeId { get; private set; }

        private DetailedAnimeTitleDTO(string name, long animeId, DetailedLanguageDTO language, long? id, DateTime creationDate, DateTime updateDate) :
            base(id, creationDate, updateDate, name, language)
        {
            AnimeId = animeId;
        }

        public static DetailedAnimeTitleDTO Create(string name, long animeId, DetailedLanguageDTO language, long? id, DateTime creationDate, DateTime updateDate)
            => new DetailedAnimeTitleDTO(name, animeId, language, id, creationDate, updateDate);
    }
}