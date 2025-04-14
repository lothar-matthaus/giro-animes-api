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
        /// <param name="fileName">Nome do arquivo da capa.</param>
        /// <param name="extension">Extensão do arquivo da capa.</param>
        /// <param name="url">Caminho onde o arquivo está hospedado.</param>
        private Cover(byte[] file, string extension, Language language) : base(extension, file)
        {
            Language = language;
        }

        /// <summary>
        /// Método para criar uma nova capa.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="extension"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public static Cover Create(byte[] file, string extension, Language language)
        {
            return new Cover(file, extension, language);
        }
    }
}
