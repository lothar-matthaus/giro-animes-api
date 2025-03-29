
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
        public IEnumerable<EpisodeTitle> Titles { get; private set; }

        /// <summary>
        /// Coleção de sinopses do episódio.
        /// </summary>
        public IEnumerable<EpisodeSinopse> Sinopses { get; private set; }

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
        public IEnumerable<EpisodeFile> Files { get; private set; }

        /// <summary>
        /// Identificador do anime ao qual o episódio pertence.
        /// </summary>
        public long AnimeId { get; private set; }

        /// <summary>
        /// Propriedade de navegação para o anime ao qual o episódio pertence.
        /// </summary>
        public Anime Anime { get; private set; }

        /// <summary>
        /// Idiomas de legendas que o episódio possui.
        /// </summary>
        public IEnumerable<Language> SubtitleLanguages { get; set; }

        /// <summary>
        /// Construtor padrão para garantir a construção do objeto no Entity Framework.
        /// </summary>
        public Episode()
        {
        }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create.
        /// </summary>
        /// <param name="files">Arquivos de vídeo do episódio.</param>
        /// <param name="titles">Coleção de títulos do episódio.</param>
        /// <param name="sinopses">Coleção de sinopses do episódio.</param>
        /// <param name="subtitleLanguage">Idiomas de legendas que o episódio possui.</param>
        /// <param name="number">Número do episódio.</param>
        /// <param name="duration">Duração do episódio em minutos.</param>
        /// <param name="airDate">Data de lançamento do episódio.</param>
        private Episode(IEnumerable<EpisodeFile> files, IEnumerable<EpisodeTitle> titles, IEnumerable<EpisodeSinopse> sinopses, IEnumerable<Language> subtitleLanguage, int number, int duration, DateTime airDate)
        {
            Titles = titles;
            Number = number;
            Duration = duration;
            Files = files;
            Sinopses = sinopses;
            SubtitleLanguages = subtitleLanguage;
            AirDate = airDate;
        }

        /// <summary>
        /// Método estático para criar um objeto Episode com validações de propriedades e retorno do objeto.
        /// </summary>
        /// <param name="files">Arquivos de vídeo do episódio.</param>
        /// <param name="titles">Coleção de títulos do episódio.</param>
        /// <param name="sinopses">Coleção de sinopses do episódio.</param>
        /// <param name="subtitleLanguage">Idiomas de legendas que o episódio possui.</param>
        /// <param name="number">Número do episódio.</param>
        /// <param name="duration">Duração do episódio em minutos.</param>
        /// <param name="airDate">Data de lançamento do episódio.</param>
        /// <returns>Uma nova instância de Episode.</returns>
        public static Episode Create(IEnumerable<EpisodeFile> files, IEnumerable<Language> subtitleLanguage, IEnumerable<EpisodeTitle> titles, IEnumerable<EpisodeSinopse> sinopses, int number, int duration, DateTime airDate) =>
            new(files, titles, sinopses, subtitleLanguage, number, duration, airDate);
    }
}
