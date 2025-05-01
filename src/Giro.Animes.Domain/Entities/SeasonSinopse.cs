using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Entities
{
    public class SeasonSinopse : Description
    {
        public long SeasonId { get; private set; }
        public Season Season { get; private set; }

        /// <summary>
        /// Construtor padrão. Garante a construção do objeto pelo EntityFramework
        /// </summary>
        public SeasonSinopse()
        {
            
        }

        /// <summary>
        /// Construtor com parâmetros. Garante a construção do objeto através do método Create
        /// </summary>
        /// <param name="description"></param>
        /// <param name="language"></param>
        private SeasonSinopse(string description, Language language, Season season = null) : base(description, language)
        {
            Season = season;
        }

        public static SeasonSinopse Create(string description, Language language, Season season = null)
        {
            return new SeasonSinopse(description, language, season);
        }
    }
}
