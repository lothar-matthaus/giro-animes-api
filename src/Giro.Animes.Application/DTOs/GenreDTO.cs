using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.DTOs
{
    public class GenreDTO : BaseDTO
    {
        public IEnumerable<GenreTitleDTO> Titles { get; private set; }

        public IEnumerable<GenreDescriptionDTO> Description { get; private set; }

        /// <summary>
        /// Private constructor to initialize GenreDTODTO with an GenreDTO entity.
        /// </summary>
        /// <param name="genre">GenreDTO entity.</param>
        private GenreDTO(long? id, DateTime creationDate, DateTime updateDate, IEnumerable<GenreTitleDTO> titles, IEnumerable<GenreDescriptionDTO> descriptions) : base(id, creationDate, updateDate)
        {
            Titles = titles;
            Description = descriptions;
        }

        /// <summary>
        /// Creates a new instance of GenreDTO.
        /// </summary>
        /// <param name="genre">Genre entity.</param>
        /// <returns>New instance of GenreDTO.</returns>
        public static GenreDTO Create(long? id, DateTime creationDate, DateTime updateDate, IEnumerable<GenreTitleDTO> titles, IEnumerable<GenreDescriptionDTO> descriptions) => new GenreDTO(id, creationDate, updateDate, titles, descriptions);
    }
}