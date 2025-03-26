using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Entities
{
    /// <summary>
    /// Representa a descrição de um anime
    /// </summary>
    public class Sinopse : Description
    {
        /// <summary>
        /// Identificador do anime ao qual a descrição pertence
        /// </summary>
        public long AnimeId { get; private set; }

        /// <summary>
        /// Propriedade de navegação para o anime da descrição
        /// </summary>
        public Anime Anime { get; private set; }

        /// <summary>
        /// Construtor padrão para garantir a construção do objeto pelo EntityFramework
        /// </summary>
        public Sinopse() { }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create
        /// </summary>
        /// <param name="text">Texto da descrição do anime</param>
        /// <param name="language">Idioma da descrição</param>
        /// <param name="anime">Anime ao qual a descrição pertence</param>
        private Sinopse(string text, Language language, Anime anime) : base(text, language)
        {
            Anime = anime;
        }

        /// <summary>
        /// Método estático para criar um objeto Sinopse com validações de propriedades e retorno do objeto
        /// </summary>
        /// <param name="text">Texto da descrição do anime</param>
        /// <param name="language">Idioma da descrição</param>
        /// <param name="anime">Anime ao qual a descrição pertence</param>
        /// <returns>Uma nova instância de Sinopse</returns>
        public static Sinopse Create(string text, Language language, Anime anime) => new Sinopse(text, language, anime);
    }
}
