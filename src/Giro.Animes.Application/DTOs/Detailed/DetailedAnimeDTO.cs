using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Domain.Enums;

namespace Giro.Animes.Application.DTOs.Detailed
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade Anime.
    /// </summary>
    public class DetailedAnimeDTO : BaseDTO
    {
        /// <summary>
        /// Coleção de títulos do anime.
        /// </summary>
        public IEnumerable<DetailedAnimeTitleDTO> Titles { get; private set; }

        /// <summary>
        /// Coleção de sinopses do anime.
        /// </summary>
        public IEnumerable<DetailedAnimeSinopseDTO> Sinopses { get; private set; }

        /// <summary>
        /// Coleção de capas do anime.
        /// </summary>
        public IEnumerable<DetailedCoverDTO> Covers { get; private set; }

        /// <summary>
        /// Coleção de capturas de tela do anime.
        /// </summary>
        public IEnumerable<DetailedAnimeScreenshotDTO> Screenshots { get; private set; }

        /// <summary>
        /// Coleção de episódios do anime.
        /// </summary>
        public IEnumerable<DetailedEpisodeDTO> Episodes { get; private set; }

        /// <summary>
        /// Coleção de autores do anime.
        /// </summary>
        public IEnumerable<DetailedAuthorDTO> Authors { get; private set; }

        /// <summary>
        /// Avaliação do anime.
        /// </summary>
        public IEnumerable<DetailedRatingDTO> Rating { get; private set; }

        /// <summary>
        /// Coleção de gêneros do anime.
        /// </summary>
        public IEnumerable<DetailedGenreDTO> Genres { get; private set; }

        /// <summary>
        /// Estúdio que criou o anime.
        /// </summary>
        public DetailedStudioDTO Studio { get; private set; }

        /// <summary>
        /// Status do anime.
        /// </summary>
        public EnumDTO<AnimeStatus> Status { get; private set; }

        /// <summary>
        /// Construtor privado para inicializar AnimeDTO com uma entidade Anime.
        /// </summary>
        /// <param name="id">Identificador do anime.</param>
        /// <param name="creationDate">Data de criação.</param>
        /// <param name="updateDate">Data de atualização.</param>
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
        private DetailedAnimeDTO(long? id, DateTime creationDate, DateTime updateDate, IEnumerable<DetailedAnimeTitleDTO> titles, IEnumerable<DetailedAnimeSinopseDTO> sinopses, IEnumerable<DetailedCoverDTO> covers, IEnumerable<DetailedAnimeScreenshotDTO> screenshots, IEnumerable<DetailedEpisodeDTO> episodes, IEnumerable<DetailedAuthorDTO> authors, IEnumerable<DetailedRatingDTO> rating, IEnumerable<DetailedGenreDTO> genres, DetailedStudioDTO studio, EnumDTO<AnimeStatus> status) :
            base(id, creationDate, updateDate)
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
        public static DetailedAnimeDTO Create(long? id, DateTime creationDate, DateTime updateDate, IEnumerable<DetailedAnimeTitleDTO> titles, IEnumerable<DetailedAnimeSinopseDTO> sinopses, IEnumerable<DetailedCoverDTO> covers, IEnumerable<DetailedAnimeScreenshotDTO> screenshots, IEnumerable<DetailedEpisodeDTO> episodes, IEnumerable<DetailedAuthorDTO> authors, IEnumerable<DetailedRatingDTO> rating, IEnumerable<DetailedGenreDTO> genres, DetailedStudioDTO studio, EnumDTO<AnimeStatus> status)
        {
            return new DetailedAnimeDTO(id, creationDate, updateDate, titles, sinopses, covers, screenshots, episodes, authors, rating, genres, studio, status);
        }
    }

}
