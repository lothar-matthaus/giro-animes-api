using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Application.DTOs.Simple;
using MimeKit.Cryptography;

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
        public IEnumerable<SimpleEpisodeTitleDTO> Titles { get; private set; }

        /// <summary>
        /// Sinopses do episódio.
        /// </summary>
        public IEnumerable<SimpleEpisodeSinopseDTO> Sinopses { get; private set; }

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
        public IEnumerable<SimpleEpisodeFileDTO> Files { get; private set; }

        /// <summary>
        /// Identificador da temporada ao qual o episódio pertence.
        /// </summary>
        public long SeasonId { get; private set; }

        /// <summary>
        /// Construtor com parâmetros. Garante a construção do objeto através do método Create.
        /// </summary>
        /// <param name="titles"></param>
        /// <param name="sinopses"></param>
        /// <param name="number"></param>
        /// <param name="duration"></param>
        /// <param name="airDate"></param>
        /// <param name="files"></param>
        /// <param name="seasonId"></param>
        /// <param name="id"></param>
        /// <param name="creationDate"></param>
        /// <param name="updateDate"></param>
        private DetailedEpisodeDTO(IEnumerable<SimpleEpisodeTitleDTO> titles, IEnumerable<SimpleEpisodeSinopseDTO> sinopses, int number, int duration, DateTime airDate, IEnumerable<SimpleEpisodeFileDTO> files, long seasonId, long? id, DateTime creationDate, DateTime updateDate) :
            base(id, creationDate, updateDate)
        {
            Titles = titles;
            Sinopses = sinopses;
            Number = number;
            Duration = duration;
            AirDate = airDate;
            Files = files;
            SeasonId = seasonId;
        }

        /// <summary>
        /// Cria uma nova instância de DetailedEpisodeDTO com os parâmetros definidos.
        /// </summary>
        /// <param name="titles"></param>
        /// <param name="sinopses"></param>
        /// <param name="number"></param>
        /// <param name="duration"></param>
        /// <param name="airDate"></param>
        /// <param name="files"></param>
        /// <param name="seasonId"></param>
        /// <param name="id"></param>
        /// <param name="creationDate"></param>
        /// <param name="updateDate"></param>
        /// <returns></returns>
        public static DetailedEpisodeDTO Create(IEnumerable<SimpleEpisodeTitleDTO> titles, IEnumerable<SimpleEpisodeSinopseDTO> sinopses, int number, int duration, DateTime airDate, IEnumerable<SimpleEpisodeFileDTO> files, long seasonId, long? id, DateTime creationDate, DateTime updateDate)
        {
            return new DetailedEpisodeDTO(titles, sinopses, number, duration, airDate, files, seasonId, id, creationDate, updateDate);

        }
    }
}