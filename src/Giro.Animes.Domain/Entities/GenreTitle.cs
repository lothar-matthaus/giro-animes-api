using Giro.Animes.Domain.Entities.Base;

namespace Giro.Animes.Domain.Entities
{
    public class GenreTitle : Title
    {
        /// <summary>
        /// Identificador a qual gênero o título pertence
        /// </summary>
        public long GenreId { get; private set; }

        /// <summary>
        /// Propriedade de navegação para o gênero do título
        /// </summary>
        public Genre Genre { get; private set; }

        /// <summary>
        /// Construtor padrão para garantir a construção do objeto pelo EntityFramework
        /// </summary>
        public GenreTitle() { }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create
        /// </summary>
        /// <param name="name">Nome do título do anime</param>
        /// <param name="language">Idioma do título</param>
        /// <param name="genre">Gênero do título</param>
        private GenreTitle(string name, Language language, Genre genre) : base(name, language)
        {
        }

        /// <summary>
        /// Método estático para criar um objeto Genretitle com validações de propriedades e retorno do objeto
        /// </summary>
        /// <param name="name">Nome do título do anime</param>
        /// <param name="language">Idioma do título</param>
        /// <param name="genre">Gênero do título</param>
        /// <returns>Uma nova instância de Genretitle</returns>
        public static GenreTitle Create(string name, Language language, Genre genre) => new GenreTitle(name, language, genre);
    }
}
