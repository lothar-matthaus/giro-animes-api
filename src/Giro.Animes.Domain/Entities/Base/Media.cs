using Giro.Animes.Domain.Constants;
using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.ValueObjects;
using System.Text.RegularExpressions;

namespace Giro.Animes.Domain.Entities
{
    public abstract class Media : EntityBase
    {
        /// <summary>
        /// Url para download ou visualização da mídia
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// Contrutor padrão
        /// </summary>
        public Media() { }

        /// <summary>
        /// Construtor com parâmetros.
        /// </summary>
        /// <param name="url"></param>
        protected Media(string url)
        {
            Url = url;
        }
    }
}
