namespace Giro.Animes.Domain.Entities
{
    public abstract class Screenshot : Media
    {
        /// <summary>
        /// Construtor padrão para garantir a construção do objeto no Entity Framework
        /// </summary>
        protected Screenshot()
        {

        }
        /// <summary>
        /// Construtor com parâmetro. Garanta a construção do objeto pelo método Create
        /// </summary>
        /// <param name="url"></param>
        /// <param name="fileName"></param>
        /// <param name="extension"></param>
        public Screenshot(byte[] file, string extension) : base(extension, file) { }
    }
}
