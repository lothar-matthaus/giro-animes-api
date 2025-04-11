using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Application.DTOs.Simple;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers
{
    /// <summary>
    /// Classe de mapeamento para o Rating.
    /// </summary>
    public static class RatingMapper
    {
        /// <summary>
        /// Método de extensão para mapear um Rating para um DetailedRatingDTO.
        /// </summary>
        /// <param name="rating"></param>
        /// <returns></returns>
        public static DetailedRatingDTO Map(this Rating rating)
        {
            DetailedRatingDTO ratingDTO = DetailedRatingDTO.Create(
                rating.Rate,
                rating.UserId,
                rating.AnimeId,
                rating.Id,
                rating.CreationDate,
                rating.UpdateDate);

            return ratingDTO;
        }

        /// <summary>
        /// Método de extensão para mapear uma coleção de Ratings para uma coleção de DetailedRatingDTOs.
        /// </summary>
        /// <param name="ratings"></param>
        /// <returns></returns>
        public static IReadOnlyCollection<DetailedRatingDTO> Map(this IEnumerable<Rating> ratings)
        {
            IReadOnlyCollection<DetailedRatingDTO> result = ratings?.Select(Map).ToList();
            return result;
        }

        /// <summary>
        /// Método de extensão para mapear um Rating para um SimpleRatingDTO.
        /// </summary>
        /// <param name="rating"></param>
        /// <returns></returns>
        public static SimpleRatingDTO MapSimple(this Rating rating)
        {
            SimpleRatingDTO simpleRatingDTO = SimpleRatingDTO.Create(rating.Rate, rating.AnimeId, rating.UserId, rating.Id.Value);

            return simpleRatingDTO;
        }

        /// <summary>
        /// Método de extensão para mapear uma coleção de Ratings para uma coleção de SimpleRatingDTOs.
        /// </summary>
        /// <param name="ratings"></param>
        /// <returns></returns>
        public static IEnumerable<SimpleRatingDTO> MapSimple(this IEnumerable<Rating> ratings)
        {
            IEnumerable<SimpleRatingDTO> result = ratings?.Select(MapSimple);
            return result;
        }
    }
}
