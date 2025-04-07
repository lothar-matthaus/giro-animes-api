using Giro.Animes.Application.DTOs;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers
{
    internal static class AnimeMapper
    {
        public static AnimeDTO Map(this Anime anime)
        {
            AnimeDTO animeDTO = AnimeDTO.Create(
                anime.Id,
                anime.CreationDate,
                anime.UpdateDate,
                anime.Titles.Map(),
                anime.Sinopses?.Map(),
                anime.Covers.Map(),
                anime.Screenshots?.Map(),
                anime.Episodes?.Map(),
                anime.Authors?.Map(),
                anime.Ratings?.Map(),
                anime.Genres.Map(),
                anime.Studio.Map(),
                anime.Status.Map()
                );
            return animeDTO;
        }

        public static IReadOnlyCollection<AnimeDTO> Map(this IEnumerable<Anime> animes)
        {
            IReadOnlyCollection<AnimeDTO> result = animes.Select(Map).ToList();
            return result;
        }
    }
}
