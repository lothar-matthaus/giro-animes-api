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
        /// Identificador do idioma do arquivo.
        /// </summary>
        public long LanguageId { get; private set; }

        /// <summary>
        /// Propriedade de navegação para o idioma do arquivo.
        /// </summary>
        public Language Language { get; private set; }

        /// <summary>
        /// Construtor padrão para garantir a construção do objeto pelo EntityFramework.
        /// </summary>
        public EpisodeFile() { }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create.
        /// </summary>
        /// <param name="episode">Episódio ao qual o arquivo pertence.</param>
        /// <param name="url">URL do arquivo.</param>
        /// <param name="fileName">Nome do arquivo.</param>
        /// <param name="extension">Extensão do arquivo.</param>
        /// <param name="language">Idioma do arquivo.</param>
        private EpisodeFile(Episode episode, string url, string fileName, string extension, Language language)
            : base(url, fileName, extension)
        {
            Episode = episode;
            Language = language;
        }

        /// <summary>
        /// Método estático para criar um objeto EpisodeFile com validações de propriedades e retorno do objeto.
        /// </summary>
        /// <param name="episode">Episódio ao qual o arquivo pertence.</param>
        /// <param name="url">URL do arquivo.</param>
        /// <param name="fileName">Nome do arquivo.</param>
        /// <param name="extension">Extensão do arquivo.</param>
        /// <param name="language">Idioma do arquivo.</param>
        /// <returns>Uma nova instância de EpisodeFile.</returns>
        public static EpisodeFile Create(Episode episode, string url, string fileName, string extension, Language language) => new EpisodeFile(episode, url, fileName, extension, language);
    }
}
