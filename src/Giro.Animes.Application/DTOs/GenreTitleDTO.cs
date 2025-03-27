using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.DTOs
{
    public class GenreTitleDTO : TitleDTO<GenreTitle>
    {
        /// <summary>
        /// Identificador a qual o título de gênero pertence.
        /// </summary>
        public long GenreId { get; private set; }

        /// <summary>
        /// Private constructor to initialize GenreTitleDTO with an GenreTitle entity.
        /// </summary>
        /// <param name="genreTitle">GenreTitle entity.</param>
        private GenreTitleDTO(GenreTitle genreTitle) : base(genreTitle)
        {
        }

        /// <summary>
        /// Private constructor to initialize GenreTitleDTO with an GenreTitle entity.
        /// </summary>
        /// <param name="genreTitle">GenreTitle entity.</param>
        public static GenreTitleDTO Create(GenreTitle genreTitle) => new GenreTitleDTO(genreTitle);
    }
}