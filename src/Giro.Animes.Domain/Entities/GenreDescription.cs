namespace Giro.Animes.Domain.Entities
{
    /// <summary>
    /// Representa a descrição de um gênero de anime.
    /// </summary>
    public class GenreDescription : Description
    {
        /// <summary>
        /// Identificador do gênero.
        /// </summary>
        public long GenreId { get; private set; }

        /// <summary>
        /// Gênero associado a esta descrição.
        /// </summary>
        public Genre Genre { get; private set; }

        /// <summary>
        /// Construtor padrão para permitir a construção do objeto pelo entity framework.
        /// </summary>
        public GenreDescription() { }

        /// <summary>
        /// Construtor com parâmetros. Garanta a construção do objeto pelo método Create.
        /// </summary>
        /// <param name="text">Texto da descrição.</param>
        /// <param name="language">Idioma da descrição.</param>
        /// <param name="genre">Gênero associado.</param>
        private GenreDescription(string text, Language language, Genre genre) : base(text, language)
        {
            Genre = genre;
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="GenreDescription"/>.
        /// </summary>
        /// <param name="text">Texto da descrição.</param>
        /// <param name="language">Idioma da descrição.</param>
        /// <param name="genre">Gênero associado.</param>
        /// <returns>Uma nova instância de <see cref="GenreDescription"/>.</returns>
        public static GenreDescription Create(string text, Language language, Genre genre) => new GenreDescription(text, language, genre);
    }
}
