using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.DTOs
{
    public class GenreDTO : BaseDTO<Genre>
    {
        public IEnumerable<GenreTitleDTO> Titles { get; private set; }

        public IEnumerable<GenreDescriptionDTO> Description { get; private set; }

        /// <summary>
        /// Private constructor to initialize GenreDTODTO with an GenreDTO entity.
        /// </summary>
        /// <param name="genre">GenreDTO entity.</param>
        private GenreDTO(Genre genre) : base(genre)
        {
            Titles = genre.Titles.Select(GenreTitleDTO.Create);
            Description = genre.Descriptions.Select(GenreDescriptionDTO.Create);
        }

        /// <summary>
        /// Creates a new instance of GenreDTO.
        /// </summary>
        /// <param name="genre">Genre entity.</param>
        /// <returns>New instance of GenreDTO.</returns>
        public static GenreDTO Create(Genre genre) => new GenreDTO(genre);
    }
}