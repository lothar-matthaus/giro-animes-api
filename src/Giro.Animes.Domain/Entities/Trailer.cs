using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Entities
{
    public class Trailer : Media
    {
        /// <summary>
        /// Identificador da temporada associada ao trailer.
        /// </summary>
        public long SeasonId { get; private set; }

        /// <summary>
        /// Temporada associada ao trailer.
        /// </summary>
        public Season Season { get; private set; }
        /// <summary>
        /// Construtor protegido. Garante a construção somente de classes derivadas.
        /// </summary>
        /// <param name="url"></param>
        protected Trailer(string url) : base(url)
        {
        }
    }
}
