using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <param name="url"></param>
        /// <param name="fileName"></param>
        /// <param name="extension"></param>
        private Logo(string url, string fileName, string extension) : base(url, fileName, extension)
        {
        }

        /// <summary>
        /// Métoddo que instancia um novo objeto do tipo Logo
        /// </summary>
        /// <param name="url"></param>
        /// <param name="fileName"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        public static Logo Create(string url, string fileName, string extension) => new Logo(url, fileName, extension);
    }
}
