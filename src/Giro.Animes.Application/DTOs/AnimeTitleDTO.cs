namespace Giro.Animes.Application.DTOs
{
    public class AnimeTitleDTO : TitleDTO
    {
        /// <summary>
        /// Identificador do anime ao qual o título pertence
        /// </summary>
        public long AnimeId { get; private set; }

        private AnimeTitleDTO(string name, long animeId, LanguageDTO language, long? id, DateTime creationDate, DateTime updateDate, DateTime? deletionDate) :
            base(id, creationDate, updateDate, deletionDate, name, language)
        {
            AnimeId = animeId;
        }

        public static AnimeTitleDTO Create(string name, long animeId, LanguageDTO language, long? id, DateTime creationDate, DateTime updateDate, DateTime? deletionDate)
            => new AnimeTitleDTO(name, animeId, language, id, creationDate, updateDate, deletionDate);
    }
}