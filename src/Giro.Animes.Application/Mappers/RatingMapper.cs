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
                rating.AnimeId,
                rating.Id,
                rating.CreationDate,
                rating.UpdateDate);

            return ratingDTO;
        }

        public static IReadOnlyCollection<RatingDTO> Map(this IEnumerable<Rating> ratings)
        {
            IReadOnlyCollection<RatingDTO> result = ratings?.Select(Map).ToList();
            return result;
        }
    }
}
