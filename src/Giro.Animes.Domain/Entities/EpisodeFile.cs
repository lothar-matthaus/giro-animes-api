namespace Giro.Animes.Domain.Entities
{
    /// <summary>
    /// Representa um arquivo de episódio.
    /// </summary>
    public class EpisodeFile : Media
    {
        /// <summary>
        /// Identificador do episódio ao qual o arquivo pertence.
        /// </summary>
        public long EpisodeId { get; private set; }

        /// <summary>
        /// Propriedade de navegação para o episódio do arquivo.
        /// </summary>
        public Episode Episode { get; private set; }

        /// <summary>
        /// Identificador do idioma de audio do arquivo
        /// </summary>
        public long AudioLanguageId { get; private set; }

        /// <summary>
        /// Propriedade de navegação para o idioma de audio do arquivo.
        /// </summary>
        public Language AudioLanguage { get; private set; }

        /// <summary>
        /// Identificador do idioma da legenda do arquivo.
        /// </summary>
        public long SubtitleLanguageId { get; set; }

        /// <summary>
        /// Propriedade de navegação para o idioma da legenda do arquivo.
        /// </summary>
        public Language SubtitleLanguage { get; private set; }

        /// <summary>
        /// Construtor padrão para garantir a construção do objeto pelo EntityFramework.
        /// </summary>
        public EpisodeFile() { }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="episode"></param>
        /// <param name="audioLanguage"></param>
        /// <param name="subtitleLanguage"></param>
        private EpisodeFile(string url, Episode episode, Language audioLanguage, Language subtitleLanguage)
            : base(url)
        {
            Episode = episode;
            AudioLanguage = audioLanguage;
            SubtitleLanguage = subtitleLanguage;
        }

        /// <summary>
        /// Cria uma nova instância de EpisodeFile com os parâmetros definidos.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="episode"></param>
        /// <param name="extension"></param>
        /// <param name="audioLanguage"></param>
        /// <param name="episodeLanguage"></param>
        /// <returns></returns>
        public static EpisodeFile Create(string url, Episode episode, string extension, Language audioLanguage, Language episodeLanguage) => new EpisodeFile(url, episode, audioLanguage, episodeLanguage);
    }
}
