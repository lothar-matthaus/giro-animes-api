namespace Giro.Animes.Domain.Entities
{
    /// <summary>
    /// Representa a capa de um anime.
    /// </summary>
    public class Cover : Media
    {
        /// <summary>
        /// Identificador do idioma da capa
        /// </summary>
        public long LanguageId { get; set; }
        /// <summary>
        /// Idioma da capa.
        /// </summary>
        public Language Language { get; private set; }

        /// <summary>
        /// Identificador do anime ao qual a capa pertence.
        /// </summary>
        public long AnimeId { get; private set; }

        /// <summary>
        /// Anime ao qual a capa pertence.
        /// </summary>
        public Anime Anime { get; private set; }

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public Cover() { }

        /// <summary>
        /// Construtor com parâmetros. Garanta a construção do objeto com o método Create.
        /// </summary>
        /// <param name="path">Caminho do arquivo da capa.</param>
        /// <param name="fileName">Nome do arquivo da capa.</param>
        /// <param name="extension">Extensão do arquivo da capa.</param>
        private Cover(string path, string fileName, string extension, Anime anime, Language language) : base(path, fileName, extension)
        {
            Language = language;
            Anime = anime;
        }

        /// <summary>
        /// Método para a construção do objeto.
        /// </summary>
        /// <param name="path">Caminho do arquivo da capa.</param>
        /// <param name="fileName">Nome do arquivo da capa.</param>
        /// <param name="extension">Extensão do arquivo da capa.</param>
        /// <param name="language">Idioma da capa.</param>
        /// <param name="anime">Anime ao qual a capa pertence.</param>
        /// <returns>Uma nova instância de Cover.</returns>
        public static Cover Create(string path, string fileName, string extension, Language language, Anime anime) => new Cover(path, fileName, extension, anime, language);
    }
}
