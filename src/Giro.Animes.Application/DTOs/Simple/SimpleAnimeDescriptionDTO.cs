using Giro.Animes.Application.DTOs;
using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.DTOs.Simple
{
    public class SimpleAnimeDescriptionDTO : SimpleDescriptionDTO
    {
        /// <summary>
        /// ID do anime associado a esta descrição.
        /// </summary>
        public long AnimeId { get; private set; }

        /// <summary>
        /// Construtor privado para garantir que o objeto só pode ser criado através do método de fábrica.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="animeId"></param>
        /// <param name="description"></param>
        /// <param name="language"></param>
        private SimpleAnimeDescriptionDTO(long id, long animeId, string description, SimpleLanguageDTO language) : base(description, language, id)
        {
            AnimeId = animeId;
        }

        /// <summary>
        /// Método de fábrica para criar um SimpleAnimeDescriptionDTO.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="animeId"></param>
        /// <param name="description"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public static SimpleAnimeDescriptionDTO Create(long id, long animeId, string description, SimpleLanguageDTO language)
        {
            return new SimpleAnimeDescriptionDTO(id, animeId, description, language);
        }
    }
}