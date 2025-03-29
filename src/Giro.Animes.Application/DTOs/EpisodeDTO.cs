using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.DTOs
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade Episode.
    /// </summary>
    public class EpisodeDTO : BaseDTO
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
        /// Data de exibição do episódio.
        /// </summary>
        public DateTime AirDate { get; private set; }


        /// <summary>
        /// Arquivo de vídeo do episódio em questão.
        /// </summary>
        public IEnumerable<EpisodeFileDTO> Files { get; private set; }

        /// <summary>
        /// Identificador do anime ao qual o episódio pertence.
        /// </summary>
        public long AnimeId { get; private set; }

        private EpisodeDTO(IEnumerable<EpisodeTitleDTO> titles, IEnumerable<EpisodeSinopseDTO> animeSinopses, int number, int duration, DateTime airDate, IEnumerable<EpisodeFileDTO> episodeFiles, long animeId, long? id, DateTime creationDate, DateTime updateDate, DateTime? deletionDate) : base(id, creationDate, updateDate, deletionDate)
        {
            Titles = titles;
            Sinopses = animeSinopses;
            Number = number;
            Duration = duration;
            Files = episodeFiles;
            AnimeId = animeId;
            AirDate = airDate;
        }

        public static EpisodeDTO Create(IEnumerable<EpisodeTitleDTO> titles, IEnumerable<EpisodeSinopseDTO> animeSinopses, int number, int duration, DateTime airDate, IEnumerable<EpisodeFileDTO> episodeFiles, long animeId, long? id, DateTime creationDate, DateTime updateDate, DateTime? deletionDate)
            => new EpisodeDTO(titles, animeSinopses, number, duration, airDate, episodeFiles, animeId, id, creationDate, updateDate, deletionDate);
    }
}