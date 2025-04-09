using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers.Detailed
{
    public static class RatingMapper
    {
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

        public static IReadOnlyCollection<DetailedRatingDTO> Map(this IEnumerable<Rating> ratings)
        {
            IReadOnlyCollection<DetailedRatingDTO> result = ratings?.Select(Map).ToList();
            return result;
        }
    }
}
