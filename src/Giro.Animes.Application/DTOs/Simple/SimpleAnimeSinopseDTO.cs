using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.DTOs.Simple
{
    public class SimpleAnimeSinopseDTO : SimpleDescriptionDTO
    {
        /// <summary>
        /// Id do anime associado a esta sinopse.
        /// </summary>
        public long AnimeId { get; private set; }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="language"></param>
        /// <param name="animeId"></param>
        /// <param name="id"></param>
        private SimpleAnimeSinopseDTO(string text, SimpleLanguageDTO language, long animeId, long? id)
            : base(text, language, id)
        {
            AnimeId = animeId;
        }

        /// <summary>
        /// Cria uma instância de SimpleAnimeSinopseDTO.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="language"></param>
        /// <param name="animeId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SimpleAnimeSinopseDTO Create(string text, SimpleLanguageDTO language, long animeId, long? id)
        {
            return new SimpleAnimeSinopseDTO(text, language, animeId, id);
        }
    }
}
