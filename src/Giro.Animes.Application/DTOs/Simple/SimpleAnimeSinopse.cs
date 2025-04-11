using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.DTOs.Simple
{
    public class SimpleAnimeSinopse : SimpleDescriptionDTO
    {
        /// <summary>
        /// Identificador do anime
        /// </summary>
        public long AnimeId { get; private set; }

        /// <summary>
        /// Cria uma nova instância de <see cref="SimpleAnimeSinopse"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="animeId"></param>
        /// <param name="description"></param>
        /// <param name="language"></param>
        private SimpleAnimeSinopse(long id, long animeId, string description, SimpleLanguageDTO language) : base(description, language, id)
        {
            AnimeId = animeId;
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="SimpleAnimeSinopse"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="animeId"></param>
        /// <param name="description"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public static SimpleAnimeSinopse Create(long id, long animeId, string description, SimpleLanguageDTO language)
        {
            return new SimpleAnimeSinopse(id, animeId, description, language);
        }
    }
}
