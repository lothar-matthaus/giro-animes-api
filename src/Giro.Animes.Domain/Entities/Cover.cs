using Giro.Animes.Domain.Constants;
using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.ValueObjects;
using System.Text.RegularExpressions;

namespace Giro.Animes.Domain.Entities
{
    public class Cover : Media
    {
        /// <summary>
        /// Identificador do cover a qual o anime pertence.
        /// </summary>
        public long AnimeId { get; private set; }

        /// <summary>
        /// Anime a qual o cover pertence
        /// </summary>
        public Cover Anime { get; private set; }

        /// <summary>
        /// Construtor com parâmetros. Garanta a construção do objeto com o método Create
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <param name="extension"></param>
        private Cover(string path, string fileName, string extension) : base()
        {
        }

        /// <summary>
        /// Método para a construção do objeto.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <param name="extension"></param>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        public static Cover Create(string path, string fileName, string extension) => new Cover(path, fileName, extension);
    }
}
