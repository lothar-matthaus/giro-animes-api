namespace Giro.Animes.Domain.Entities
{
    /// <summary>
    /// Representa uma captura de tela de um anime.
    /// </summary>
    public class AnimeScreenshot : Screenshot
    {
        /// <summary>
        /// Identificador do anime ao qual a captura de tela pertence.
        /// </summary>
        public long AnimeId { get; private set; }

        /// <summary>
        /// Propriedade de navegação para o anime da captura de tela.
        /// </summary>
        public Anime Anime { get; private set; }

        /// <summary>
        /// Construtor padrão para garantir a construção do objeto pelo EntityFramework.
        /// </summary>
        public AnimeScreenshot() { }

        /// <summary>
        /// Construtor com parâmetros. Garante a construção do objeto pelo método Create.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="extension"></param>
        /// <param name="anime"></param>
        private AnimeScreenshot(byte[] file, string extension) : base(file, extension)
        {
        }

        /// <summary>
        /// Método estático para criar uma nova instância de AnimeScreenshot. 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        public static AnimeScreenshot Create(byte[] file, string extension) => new AnimeScreenshot(file, extension);
    }
}
