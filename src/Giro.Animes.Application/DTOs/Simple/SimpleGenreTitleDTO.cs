using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.DTOs.Simple
{
    public class SimpleGenreTitleDTO : SimpleTitleDTO
    {
        /// <summary>
        /// The unique identifier for the genre.
        /// </summary>
        public long GenreId { get; private set; }

        /// <summary>
        /// Private constructor to initialize SimpleGenreTitleDTO with a title and language.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="language"></param>
        /// <param name="genreId"></param>
        private SimpleGenreTitleDTO(long id, string name, SimpleLanguageDTO language, long genreId) : base(name, language, id)
        {
            GenreId = genreId;
        }

        /// <summary>
        /// Creates a new instance of SimpleGenreTitleDTO.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="language"></param>
        /// <param name="genreId"></param>
        /// <returns></returns>
        public static SimpleGenreTitleDTO Create(long id, string name, SimpleLanguageDTO language, long genreId)
        {
            return new SimpleGenreTitleDTO(id, name, language, genreId);
        }
    }
}
