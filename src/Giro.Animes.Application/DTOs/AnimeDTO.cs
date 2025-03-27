
using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;
using System.Threading.Tasks;

namespace Giro.Animes.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for Anime entity.
    /// </summary>
    public class AnimeDTO : BaseDTO<Anime>
    {
        /// <summary>
        /// Collection of anime titles.
        /// </summary>
        public IEnumerable<AnimeTitleDTO> Titles { get; private set; }
        /// <summary>
        /// Collection of anime synopses.
        /// </summary>
        public IEnumerable<AnimeSinopseDTO> Sinopses { get; private set; }
        /// <summary>
        /// Collection of anime covers.
        /// </summary>
        public IEnumerable<CoverDTO> Covers { get; private set; }
        /// <summary>
        /// Collection of anime screenshots.
        /// </summary>
        public IEnumerable<AnimeScreenshotDTO> Screenshots { get; private set; }
        /// <summary>
        /// Collection of anime episodes.
        /// </summary>
        public IEnumerable<EpisodeDTO> Episodes { get; private set; }
        /// <summary>
        /// Collection of anime authors.
        /// </summary>
        public IEnumerable<AuthorDTO> Authors { get; private set; }
        /// <summary>
        /// Anime rating
        /// </summary>
        public double Rating { get; private set; }
        /// <summary>
        /// Collection of anime genres.
        /// </summary>
        public IEnumerable<GenreDTO> Genres { get; private set; }
        /// <summary>
        /// Studio that created the anime.
        /// </summary>
        public StudioDTO Studio { get; private set; }
        /// <summary>
        /// Status of the anime.
        /// </summary>
        public KeyValueDTO Status { get; private set; }

        /// <summary>
        /// Private constructor to initialize AnimeDTO with an Anime entity.
        /// </summary>
        /// <param name="anime">Anime entity.</param>
        private AnimeDTO(Anime anime) : base(anime)
        {
            Titles = anime.Titles.Select(AnimeTitleDTO.Create);
            Sinopses = anime.Sinopses.Select(AnimeSinopseDTO.Create);
            Covers = anime.Covers.Select(CoverDTO.Create);
            Screenshots = anime.Screenshots.Select(AnimeScreenshotDTO.Create);
            Episodes = anime.Episodes.Select(EpisodeDTO.Create);
            Authors = anime.Authors.Select(AuthorDTO.Create);
            Rating = Math.Round(anime.Ratings.Sum(rating => rating.Rate) / anime.Ratings.Count);
            Genres = anime.Genres.Select(GenreDTO.Create);
            Studio = StudioDTO.Create(anime.Studio);
            Status = KeyValueDTO.Create(anime.Status.Value, anime.Status.Name);
        }

        /// <summary>
        /// Creates a new instance of AnimeDTO.
        /// </summary>
        /// <param name="anime">Anime entity.</param>
        /// <returns>New instance of AnimeDTO.</returns>
        public static AnimeDTO Create(Anime anime)
        {
            return new AnimeDTO(anime);
        }
    }

}
