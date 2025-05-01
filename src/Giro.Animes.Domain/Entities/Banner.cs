using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Entities
{
    public class Banner : Media
    {
        public long AnimeId { get; set; }

        /// <summary>
        /// Construtor padrão para garantir a construção do objeto pelo EntityFramework.
        /// </summary>
        public Banner()
        {
            
        }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create
        /// </summary>
        /// <param name="url"></param>
        private Banner(string url) : base(url)
        {
        }

        /// <summary>
        /// Método para criar um banner.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static Banner Create(string url)
        {
            return new Banner(url);
        }
    }
}
