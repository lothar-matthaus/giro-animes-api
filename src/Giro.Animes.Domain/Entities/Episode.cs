
using Giro.Animes.Domain.Entities.Base;

namespace Giro.Animes.Domain.Entities
{
    /// <summary>
    /// Representa um episódio de um anime.
    /// </summary>
    public class Episode : EntityBase
    {
        /// <summary>
        /// Coleção de títulos do episódio.
        /// </summary>
        public ICollection<EpisodeTitle> Titles { get; private set; }

        /// <summary>
        /// Coleção de sinopses do episódio.
        /// </summary>
        public ICollection<EpisodeSinopse> Sinopses { get; private set; }

        /// <summary>
        /// Número do episódio.
        /// </summary>
        public int Number { get; private set; }

        /// <summary>
        /// Duração do episódio em minutos.
        /// </summary>
        public int Duration { get; private set; }

        /// <summary>
        /// Data de lançamento do episódio.
        /// </summary>
        public DateTime AirDate { get; private set; }

        /// <summary>
        /// Arquivos de vídeo do episódio.
        /// </summary>
        public ICollection<EpisodeFile> Files { get; private set; }

        /// <summary>
        /// Identificador da temporada ao qual o episódio pertence.
        /// </summary>
        public long SeasonId { get; private set; }

        /// <summary>
        /// Propriedade de navegação para a temporada ao qual o episódio pertence.
        /// </summary>
        public Season Season { get; private set; }

        /// <summary>
        /// Idiomas disponíveis para legendas no episódio.
        /// </summary>
        public ICollection<Language> AudioLanguages { get; private set; }

        public ICollection<Language> SubtitleLanaguages { get; private set; }

        /// <summary>
        /// Construtor padrão para garantir a construção do objeto no Entity Framework.
        /// </summary>
        public Episode()
        {
        }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create.
        /// </summary>
        /// <param name="files"></param>
        /// <param name="titles"></param>
        /// <param name="sinopses"></param>
        /// <param name="number"></param>
        /// <param name="duration"></param>
        /// <param name="airDate"></param>
        private Episode(ICollection<EpisodeFile> files, ICollection<EpisodeTitle> titles, ICollection<EpisodeSinopse> sinopses, int number, int duration, DateTime airDate)
        {
            Titles = titles;
            Number = number;
            Duration = duration;
            Files = files;
            Sinopses = sinopses;
            AirDate = airDate;
            AudioLanguages = Files?.Select(file => file.AudioLanguage).DistinctBy(lan => lan.Id).ToList();
            SubtitleLanaguages = Files?.Select(file => file.SubtitleLanguage).DistinctBy(lan => lan.Id).ToList();
        }

        /// <summary>
        /// Método estático para criar um objeto Episode com validações de propriedades e retorno do objeto.
        /// </summary>
        /// <param name="files"></param>
        /// <param name="titles"></param>
        /// <param name="sinopses"></param>
        /// <param name="number"></param>
        /// <param name="duration"></param>
        /// <param name="airDate"></param>
        /// <returns></returns>
        public static Episode Create(ICollection<EpisodeFile> files, ICollection<EpisodeTitle> titles, ICollection<EpisodeSinopse> sinopses, int number, int duration, DateTime airDate) =>
            new(files, titles, sinopses, number, duration, airDate);
    }
}
