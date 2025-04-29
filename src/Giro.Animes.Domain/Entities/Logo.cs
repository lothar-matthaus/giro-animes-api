namespace Giro.Animes.Domain.Entities
{
    public class Logo : Media
    {
        /// <summary>
        /// Identificador do estúdio a qual o estúdio pertence.
        /// </summary>
        public long StudioId { get; private set; }

        /// <summary>
        /// Propriedade de navegação do Studio
        /// </summary>
        public Studio Studio { get; private set; }

        /// <summary>
        /// Construtor padrão, para garantir a construção do objeto no Entity Framework
        /// </summary>
        public Logo() { }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="studio"></param>
        private Logo(string url, Studio studio) : base(url)
        {
            Studio = studio;
        }

        /// <summary>
        /// Cria uma instância de Logo com os parâmetros necessários.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="studio"></param>
        /// <returns></returns>
        public static Logo Create(string url, Studio studio) => new Logo(url, studio);
    }
}
