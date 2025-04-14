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
        /// Construtor com parâmetros. Garanta a construção do objeto no método Create
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="extension"></param>
        private Logo(byte[] file, string extension, Studio studio) : base(extension, file)
        {
            Studio = studio;
        }

        /// <summary>
        /// Métoddo que instancia um novo objeto do tipo Logo
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        public static Logo Create(byte[] file, string extension, Studio studio) => new Logo(file, extension, studio);
    }
}
