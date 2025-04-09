using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.DTOs.Detailed
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade Episode.
    /// </summary>
    public class DetailedEpisodeDTO : BaseDTO
    {
        /// <summary>
        /// Coleção de títulos do episódio.
        /// </summary>
        public IEnumerable<DetailedEpisodeTitleDTO> Titles { get; private set; }

        /// <summary>
        /// Sinopses do episódio.
        /// </summary>
        public IEnumerable<DetailedEpisodeSinopseDTO> Sinopses { get; private set; }

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
        public IEnumerable<DetailedEpisodeFileDTO> Files { get; private set; }

        /// <summary>
        /// Identificador do anime ao qual o episódio pertence.
        /// </summary>
        public long AnimeId { get; private set; }

        private DetailedEpisodeDTO(IEnumerable<DetailedEpisodeTitleDTO> titles, IEnumerable<DetailedEpisodeSinopseDTO> animeSinopses, int number, int duration, DateTime airDate, IEnumerable<DetailedEpisodeFileDTO> episodeFiles, long animeId, long? id, DateTime creationDate, DateTime updateDate) :
            base(id, creationDate, updateDate)
        {
            Titles = titles;
            Sinopses = animeSinopses;
            Number = number;
            Duration = duration;
            Files = episodeFiles;
            AnimeId = animeId;
            AirDate = airDate;
        }

        public static DetailedEpisodeDTO Create(IEnumerable<DetailedEpisodeTitleDTO> titles, IEnumerable<DetailedEpisodeSinopseDTO> animeSinopses, int number, int duration, DateTime airDate, IEnumerable<DetailedEpisodeFileDTO> episodeFiles, long animeId, long? id, DateTime creationDate, DateTime updateDate)
            => new DetailedEpisodeDTO(titles, animeSinopses, number, duration, airDate, episodeFiles, animeId, id, creationDate, updateDate);
    }
}