using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Entities
{
    /// <summary>
    /// Representa uma captura de tela de um anime.
    /// </summary>
    public class AnimeScreenshot : Screenshot
    {
        /// <summary>
        /// Identificador do anime ao qual a captura de tela pertence.
        /// </summary>
        public long AnimeId { get; private set; }

        /// <summary>
        /// Propriedade de navegação para o anime da captura de tela.
        /// </summary>
        public Anime Anime { get; private set; }

        /// <summary>
        /// Construtor padrão para garantir a construção do objeto pelo EntityFramework.
        /// </summary>
        public AnimeScreenshot() { }

        /// <summary>
        /// Construtor com parâmetros. Garante a construção do objeto pelo método Create.
        /// </summary>
        /// <param name="fileName">Nome do arquivo da captura de tela.</param>
        /// <param name="extension">Extensão do arquivo da captura de tela.</param>
        private AnimeScreenshot(string url, string fileName, string extension, Anime anime) : base(url, fileName, extension)
        {
            Anime = anime;
        }

        /// <summary>
        /// Método estático para criar um objeto AnimeScreenshot com validações de propriedades e retorno do objeto.
        /// </summary>
        /// <param name="fileName">Nome do arquivo da captura de tela.</param>
        /// <param name="extension">Extensão do arquivo da captura de tela.</param>
        /// <param name="anime">Propriedade de navegação para o anime da captura de tela.</param>
        /// <returns>Uma nova instância de AnimeScreenshot.</returns>
        public static AnimeScreenshot Create(string url, string fileName, string extension, Anime anime) => new AnimeScreenshot(url, fileName, extension, anime);
    }
}
