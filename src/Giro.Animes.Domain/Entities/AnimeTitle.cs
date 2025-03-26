using Giro.Animes.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Entities
{
    public class AnimeTitle : Title
    {
        /// <summary>
        /// Identificador do anime ao qual o título pertence
        /// </summary>
        public long AnimeId { get; private set; }

        /// <summary>
        /// Propriedade de navegação para o anime do título
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
        /// <param name="anime">Anime ao qual o título pertence</param>
        private AnimeTitle(string name, Language language, Anime anime) : base(name, language)
        {
            Anime = anime;
        }

        /// <summary>
        /// Método estático para criar um objeto AnimeTitle com validações de propriedades e retorno do objeto
        /// </summary>
        /// <param name="name">Nome do título do anime</param>
        /// <param name="language">Idioma do título</param>
        /// <param name="anime">Anime ao qual o título pertence</param>
        /// <returns>Uma nova instância de AnimeTitle</returns>
        public static AnimeTitle Create(string name, Language language, Anime anime) => new AnimeTitle(name, language, anime);
    }
}
