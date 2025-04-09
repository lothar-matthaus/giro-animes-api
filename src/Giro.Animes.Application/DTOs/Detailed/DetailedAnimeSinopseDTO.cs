using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.DTOs.Detailed
{
    public class DetailedAnimeSinopseDTO : DescriptionDTO
    {

        /// <summary>  
        /// Identificador do anime ao qual a descrição pertence  
        /// </summary>  
        public long AnimeId { get; private set; }

        private DetailedAnimeSinopseDTO(long? id, DateTime creationDate, DateTime updateDate, long animeId, string text, DetailedLanguageDTO language) : base(id, creationDate, updateDate, text, language)
        {
            AnimeId = animeId;
        }
        public static DetailedAnimeSinopseDTO Create(long? id, DateTime creationDate, DateTime updateDate, long animeId, string text, DetailedLanguageDTO language)
            => new DetailedAnimeSinopseDTO(id, creationDate, updateDate, animeId, text, language);
    }
}