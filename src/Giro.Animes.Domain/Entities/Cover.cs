namespace Giro.Animes.Domain.Entities
{
    /// <summary>
    /// Representa a capa de um anime.
    /// </summary>
    public class Cover : Media
    {
        /// <summary>
        /// Identificador do anime ao qual a capa pertence.
        /// </summary>
        public long AnimeId { get; private set; }

        /// <summary>
        /// Propriedade de navegação do Anime.
        /// </summary>
        public Anime Anime { get; private set; }

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public Cover() { }


        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create.
        /// </summary>
        /// <param name="url"></param>
        private Cover(string url) : base(url)
        {
        }

        /// <summary>
        /// Cria uma nova instância de Cover.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public static Cover Create(string url)
        {
            return new Cover(url);
        }
    }
}
