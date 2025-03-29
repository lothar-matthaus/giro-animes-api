using Giro.Animes.Application.DTOs;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers
{
    public static class RatingMapper
    {
        public static RatingDTO Map(this Rating rating)
        {
            RatingDTO ratingDTO = RatingDTO.Create(
                rating.Rate,
                rating.UserId,
                rating.Id,
                rating.CreationDate,
                rating.UpdateDate,
                rating.AnimeId);
            return ratingDTO;
        }

        public static IEnumerable<RatingDTO> Map(this IEnumerable<Rating> ratings)
        {
            IEnumerable<RatingDTO> result = ratings?.Select(Map);
            return result;
        }
    }
}
