using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.DTOs.Detailed
{
    public class DetailedGenreDTO : BaseDTO
    {
        public IEnumerable<DetailedGenreTitleDTO> Titles { get; private set; }

        public IEnumerable<DetailedGenreDescriptionDTO> Description { get; private set; }

        /// <summary>
        /// Private constructor to initialize GenreDTODTO with an GenreDTO entity.
        /// </summary>
        /// <param name="genre">GenreDTO entity.</param>
        private DetailedGenreDTO(long? id, DateTime creationDate, DateTime updateDate, IEnumerable<DetailedGenreTitleDTO> titles, IEnumerable<DetailedGenreDescriptionDTO> descriptions) : base(id, creationDate, updateDate)
        {
            Titles = titles;
            Description = descriptions;
        }

        /// <summary>
        /// Creates a new instance of GenreDTO.
        /// </summary>
        /// <param name="genre">Genre entity.</param>
        /// <returns>New instance of GenreDTO.</returns>
        public static DetailedGenreDTO Create(long? id, DateTime creationDate, DateTime updateDate, IEnumerable<DetailedGenreTitleDTO> titles, IEnumerable<DetailedGenreDescriptionDTO> descriptions) => new DetailedGenreDTO(id, creationDate, updateDate, titles, descriptions);
    }
}