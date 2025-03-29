
using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Domain.Enums;

namespace Giro.Animes.Application.DTOs
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade Anime.
    /// </summary>
    public class AnimeDTO : BaseDTO
    {
        /// <summary>
        /// Coleção de títulos do anime.
        /// </summary>
        public IEnumerable<AnimeTitleDTO> Titles { get; private set; }

        /// <summary>
        /// Coleção de sinopses do anime.
        /// </summary>
        public IEnumerable<AnimeSinopseDTO> Sinopses { get; private set; }

        /// <summary>
        /// Coleção de capas do anime.
        /// </summary>
        public IEnumerable<CoverDTO> Covers { get; private set; }

        /// <summary>
        /// Coleção de capturas de tela do anime.
        /// </summary>
        public IEnumerable<AnimeScreenshotDTO> Screenshots { get; private set; }

        /// <summary>
        /// Coleção de episódios do anime.
        /// </summary>
        public IEnumerable<EpisodeDTO> Episodes { get; private set; }

        /// <summary>
        /// Coleção de autores do anime.
        /// </summary>
        public IEnumerable<AuthorDTO> Authors { get; private set; }

        /// <summary>
        /// Avaliação do anime.
        /// </summary>
        public IEnumerable<RatingDTO> Rating { get; private set; }

        /// <summary>
        /// Coleção de gêneros do anime.
        /// </summary>
        public IEnumerable<GenreDTO> Genres { get; private set; }

        /// <summary>
        /// Estúdio que criou o anime.
        /// </summary>
        public StudioDTO Studio { get; private set; }

        /// <summary>
        /// Status do anime.
        /// </summary>
        public EnumDTO<int> Status { get; private set; }

        /// <summary>
        /// Construtor privado para inicializar AnimeDTO com uma entidade Anime.
        /// </summary>
        /// <param name="id">Identificador do anime.</param>
        /// <param name="creationDate">Data de criação.</param>
        /// <param name="updateDate">Data de atualização.</param>
        /// <param name="deletionDate">Data de exclusão.</param>
        /// <param name="titles">Coleção de títulos do anime.</param>
        /// <param name="sinopses">Coleção de sinopses do anime.</param>
        /// <param name="covers">Coleção de capas do anime.</param>
        /// <param name="screenshots">Coleção de capturas de tela do anime.</param>
        /// <param name="episodes">Coleção de episódios do anime.</param>
        /// <param name="authors">Coleção de autores do anime.</param>
        /// <param name="rating">Avaliação do anime.</param>
        /// <param name="genres">Coleção de gêneros do anime.</param>
        /// <param name="studio">Estúdio que criou o anime.</param>
        /// <param name="status">Status do anime.</param>
        private AnimeDTO(long? id, DateTime creationDate, DateTime updateDate, DateTime? deletionDate, IEnumerable<AnimeTitleDTO> titles, IEnumerable<AnimeSinopseDTO> sinopses, IEnumerable<CoverDTO> covers, IEnumerable<AnimeScreenshotDTO> screenshots, IEnumerable<EpisodeDTO> episodes, IEnumerable<AuthorDTO> authors, IEnumerable<RatingDTO> rating, IEnumerable<GenreDTO> genres, StudioDTO studio, EnumDTO<int> status) :
            base(id, creationDate, updateDate, deletionDate)
        {
            Titles = titles;
            Sinopses = sinopses;
            Covers = covers;
            Screenshots = screenshots;
            Episodes = episodes;
            Authors = authors;
            Rating = rating;
            Genres = genres;
            Studio = studio;
            Status = status;
        }

        /// <summary>
        /// Cria uma nova instância de AnimeDTO.
        /// </summary>
        /// <param name="id">Identificador do anime.</param>
        /// <param name="creationDate">Data de criação.</param>
        /// <param name="updateDate">Data de atualização.</param>
        /// <param name="deletionDate">Data de exclusão.</param>
        /// <param name="titles">Coleção de títulos do anime.</param>
        /// <param name="sinopses">Coleção de sinopses do anime.</param>
        /// <param name="covers">Coleção de capas do anime.</param>
        /// <param name="screenshots">Coleção de capturas de tela do anime.</param>
        /// <param name="episodes">Coleção de episódios do anime.</param>
        /// <param name="authors">Coleção de autores do anime.</param>
        /// <param name="rating">Avaliação do anime.</param>
        /// <param name="genres">Coleção de gêneros do anime.</param>
        /// <param name="studio">Estúdio que criou o anime.</param>
        /// <param name="status">Status do anime.</param>
        /// <returns>Nova instância de AnimeDTO.</returns>
        public static AnimeDTO Create(long? id, DateTime creationDate, DateTime updateDate, DateTime? deletionDate, IEnumerable<AnimeTitleDTO> titles, IEnumerable<AnimeSinopseDTO> sinopses, IEnumerable<CoverDTO> covers, IEnumerable<AnimeScreenshotDTO> screenshots, IEnumerable<EpisodeDTO> episodes, IEnumerable<AuthorDTO> authors, IEnumerable<RatingDTO> rating, IEnumerable<GenreDTO> genres, StudioDTO studio, EnumDTO<int> status)
        {
            return new AnimeDTO(id, creationDate, updateDate, deletionDate, titles, sinopses, covers, screenshots, episodes, authors, rating, genres, studio, status);
        }
    }

}
