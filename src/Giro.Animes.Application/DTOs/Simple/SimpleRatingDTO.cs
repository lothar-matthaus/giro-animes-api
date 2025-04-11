using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.DTOs.Simple
{
    public class SimpleRatingDTO : BaseSimpleDTO
    {
        /// <summary>
        /// Nota do anime
        /// </summary>
        public double Rate { get; private set; }

        /// <summary>
        /// Identificador do anime
        /// </summary>
        public long AnimeId { get; private set; }

        /// <summary>
        /// Identificador do usuário que fez a avaliação
        /// </summary>
        public long UserId { get; private set; }

        /// <summary>
        /// Construtor privado para garantir que o objeto só pode ser criado através do método de fábrica.
        /// </summary>
        /// <param name="rate"></param>
        /// <param name="animeId"></param>
        /// <param name="userId"></param>
        /// <param name="id"></param>
        private SimpleRatingDTO(
            double rate, long animeId, long userId, long id) : base(id)
        {
            Rate = rate;
            AnimeId = animeId;
            UserId = userId;
        }

        /// <summary>
        /// Método fábrica para criar um novo objeto SimpleRatingDTO.
        /// </summary>
        /// <param name="rate"></param>
        /// <param name="animeId"></param>
        /// <param name="userId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SimpleRatingDTO Create(double rate, long animeId, long userId, long id)
        {
            return new SimpleRatingDTO(rate, animeId, userId, id);
        }
    }
}
