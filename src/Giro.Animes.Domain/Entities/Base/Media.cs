using Giro.Animes.Domain.Constants;
using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.ValueObjects;
using System.Text.RegularExpressions;

namespace Giro.Animes.Domain.Entities
{
    public abstract class Media : EntityBase
    {
        private string _url;

        public string Url
        {
            get { return _url; }
            set
            {
                Validate(
                    isInvalidIf: string.IsNullOrWhiteSpace(value),
                    ifInvalid: () => Notification.Create(this.GetType().Name, nameof(Url), string.Format("{0}. Verifique a URL de mídia.", Message.Validation.General.INVALID_URL)),
                    ifValid:() => _url = value);
            }
        }


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
