using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.DTOs
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade Episode.
    /// </summary>
    public class EpisodeDTO : BaseDTO<Episode>
    {
        /// <summary>
        /// Coleção de títulos do episódio.
        /// </summary>
        public IEnumerable<EpisodeTitleDTO> Titles { get; private set; }

        /// <summary>
        /// Sinopses do episódio.
        /// </summary>
        public IEnumerable<EpisodeSinopseDTO> Sinopses { get; private set; }

        /// <summary>
        /// Número do episódio.
        /// </summary>
        public int Number { get; private set; }

        /// <summary>
        /// Duração do episódio em minutos.
        /// </summary>
        public int Duration { get; private set; }

        /// <summary>
        /// Arquivo de vídeo do episódio em questão.
        /// </summary>
        public IEnumerable<EpisodeFileDTO> Files { get; private set; }

        /// <summary>
        /// Identificador do anime ao qual o episódio pertence.
        /// </summary>
        public long AnimeId { get; private set; }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="EpisodeDTO"/>.
        /// </summary>
        /// <param name="episode">A entidade Episode.</param>
        private EpisodeDTO(Episode episode) : base(episode)
        {
            Titles = episode.Titles.Select(EpisodeTitleDTO.Create).ToList();
            Sinopses = episode.Sinopses.Select(EpisodeSinopseDTO.Create).ToList();
            Number = episode.Number;
            Duration = episode.Duration;
            Files = episode.Files.Select(EpisodeFileDTO.Create).ToList();
            AnimeId = episode.AnimeId;
        }

        /// <summary>
        /// Cria uma nova instância da classe <see cref="EpisodeDTO"/> a partir de uma entidade <see cref="Episode"/>.
        /// </summary>
        /// <param name="episode">A entidade Episode.</param>
        /// <returns>Uma nova instância de <see cref="EpisodeDTO"/>.</returns>
        public static EpisodeDTO Create(Episode episode) => new EpisodeDTO(episode);
    }
}