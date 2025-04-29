using Giro.Animes.Domain.Entities.Base;

namespace Giro.Animes.Domain.Entities
{
    /// <summary>
    /// Representa uma captura de tela de um anime.
    /// </summary>
    public class Screenshot : Media
    {
        /// <summary>
        /// Identificador do anime ao qual a captura de tela pertence.
        /// </summary>
        public long AnimeId { get; private set; }

        /// <summary>
        /// Propriedade de navegação para o anime associado a esta captura de tela.
        /// </summary>
        public Anime Anime { get; private set; }

        /// <summary>
        /// Construtor padrão para garantir a construção do objeto pelo EntityFramework.
        /// </summary>
        public Screenshot() { }

        /// <summary>
        /// Construtor privado para garantir a construção do objeto através do método Create.
        /// </summary>
        /// <param name="url"></param>
        private Screenshot(string url) : base(url)
        {
        }

        /// <summary>
        /// Método estático para criar uma nova instância de Screenshot.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static Screenshot Create(string url) => new Screenshot(url);
    }
}
