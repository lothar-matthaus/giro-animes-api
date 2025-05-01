using Giro.Animes.Domain.Constants;
using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.ValueObjects;

namespace Giro.Animes.Domain.Entities
{
    public class AnimeTitle : Title
    {
        /// <summary>
        /// Identificador do anime ao qual o título pertence
        /// </summary>
        public long AnimeId { get; private set; }

        /// <summary>
        /// Anime ao qual o título pertence
        /// </summary>
        public Anime Anime { get; private set; }
        /// <summary>
        /// Construtor padrão para garantir a construção do objeto pelo EntityFramework
        /// </summary>
        public AnimeTitle() { }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create
        /// </summary>
        /// <param name="name">Nome do título do anime</param>
        /// <param name="language">Idioma do título</param>
        private AnimeTitle(string name, Language language) : base(name, language)
        {
        }

        /// <summary>
        /// Método estático para criar um objeto AnimeTitle com validações de propriedades e retorno do objeto
        /// </summary>
        /// <param name="name">Nome do título do anime</param>
        /// <param name="language">Idioma do título</param>
        /// <returns>Uma nova instância de AnimeTitle</returns>
        public static AnimeTitle Create(string name, Language language) => new AnimeTitle(name, language);
    }
}
