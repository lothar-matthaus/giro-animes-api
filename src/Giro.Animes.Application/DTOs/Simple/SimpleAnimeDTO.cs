using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Domain.Enums;

namespace Giro.Animes.Application.DTOs.Simple
{
    public class SimpleAnimeDTO : BaseSimpleDTO
    {
        /// <summary>
        /// Títulos do anime.
        /// </summary>
        public IEnumerable<SimpleAnimeTitleDTO> Titles { get; private set; }

        /// <summary>
        /// Sinopses do anime.
        /// </summary>
        public IEnumerable<SimpleAnimeSinopseDTO> Sinopses { get; private set; }

        /// <summary>
        /// Capa do anime.
        /// </summary>
        public SimpleCoverDTO Cover { get; private set; }

        /// <summary>
        /// Capturas de tela do anime.
        /// </summary>
        public IEnumerable<SimpleAnimeScreenshotDTO> Screenshots { get; private set; }

        /// <summary>
        /// Gêneros do anime.
        /// </summary>
        public IEnumerable<SimpleGenreDTO> Genres { get; private set; }

        /// <summary>
        /// Autores do anime.
        /// </summary>
        public IEnumerable<SimpleAuthorDTO> Authors { get; private set; }

        /// <summary>
        /// Estúdio do anime.
        /// </summary>
        public SimpleStudioDTO Studio { get; private set; }

        /// <summary>
        /// Status do anime.
        /// </summary>
        public EnumDTO<AnimeStatus> Status { get; private set; }

        /// <summary>
        /// Construtor privado para garantir que a classe só pode ser instanciada através do método Create.
        /// </summary>
        /// <param name="titles"></param>
        /// <param name="sinopses"></param>
        /// <param name="cover"></param>
        /// <param name="genres"></param>
        /// <param name="authors"></param>
        /// <param name="studio"></param>
        /// <param name="status"></param>
        /// <param name="id"></param>
        private SimpleAnimeDTO(IEnumerable<SimpleAnimeTitleDTO> titles, IEnumerable<SimpleAnimeSinopseDTO> sinopses, SimpleCoverDTO cover, IEnumerable<SimpleAnimeScreenshotDTO> screenshots, IEnumerable<SimpleGenreDTO> genres, IEnumerable<SimpleAuthorDTO> authors, SimpleStudioDTO studio, EnumDTO<AnimeStatus> status, long? id) :
            base(id)
        {
            Titles = titles;
            Sinopses = sinopses;
            Cover = cover;
            Screenshots = screenshots;
            Genres = genres;
            Authors = authors;
            Studio = studio;
            Status = status;
        }

        /// <summary>
        /// Cria uma nova instância de SimpleAnimeDTO com os parâmetros fornecidos.
        /// </summary>
        /// <param name="titles"></param>
        /// <param name="sinopses"></param>
        /// <param name="cover"></param>
        /// <param name="genres"></param>
        /// <param name="authors"></param>
        /// <param name="studio"></param>
        /// <param name="status"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SimpleAnimeDTO Create(IEnumerable<SimpleAnimeTitleDTO> titles, IEnumerable<SimpleAnimeSinopseDTO> sinopses, SimpleCoverDTO cover, IEnumerable<SimpleAnimeScreenshotDTO> screenshots, IEnumerable<SimpleGenreDTO> genres, IEnumerable<SimpleAuthorDTO> authors, SimpleStudioDTO studio, EnumDTO<AnimeStatus> status, long? id)
        {
            return new SimpleAnimeDTO(titles, sinopses, cover, screenshots, genres, authors, studio, status, id);
        }
    }
}
