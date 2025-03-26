namespace Giro.Animes.Domain.Entities
{
    public class Biography : Description
    {
        /// <summary>
        /// Identificador do autor ao qual a biografia pertence
        /// </summary>
        public long AuthorId { get; private set; }

        /// <summary>
        /// Propriedade de navegação para o autor da biografia
        /// </summary>
        public Author Author { get; private set; }

        /// <summary>
        /// Construtor padrão para garantir a construção do objeto pelo EntityFramework
        /// </summary>
        public Biography()
        {
        }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create
        /// </summary>
        /// <param name="text">Texto da biografia</param>
        /// <param name="language">Idioma da biografia</param>
        /// <param name="author">Autor da biografia</param>
        private Biography(string text, Language language, Author author) : base(text, language)
        {
        }

        /// <summary>
        /// Método estático para criar um objeto Biography com validações de propriedades e retorno do objeto
        /// </summary>
        /// <param name="text">Texto da biografia</param>
        /// <param name="language">Idioma da biografia</param>
        /// <param name="author">Autor da biografia</param>
        /// <returns>Uma nova instância de Biography</returns>
        public static Biography Create(string text, Language language, Author author) => new Biography(text, language, author);
    }
}
