using Giro.Animes.Domain.Constants;
using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.ValueObjects;

namespace Giro.Animes.Domain.Entities
{
    public abstract class Description : EntityBase
    {
        /// <summary>
        /// Texto da descrição
        /// </summary>
        #region Text
        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                Validate(
                    isInvalidIf: string.IsNullOrWhiteSpace(value),
                    ifInvalid: () => Notification.Create(this.GetType().Name, "Text", string.Format(Message.Validation.General.REQUIRED, "Text")),
                    ifValid: () => _text = value);
            }
        }
        #endregion

        /// <summary>
        /// Idetificaddr do idioma da descrição
        /// </summary>
        public long LanguageId { get; private set; }

        /// <summary>
        /// Idioma da descrição
        /// </summary>
        #region Language
        private Language _language;
        public Language Language
        {
            get { return _language; }
            set
            {
                Validate(
                    isInvalidIf: value == null,
                    ifInvalid: () => Notification.Create(this.GetType().Name, "Language", string.Format(Message.Validation.Description.LANGUAGE_REQUIRED, "Language")),
                    ifValid: () => _language = value);
            }
        }
        #endregion

        /// <summary>
        /// Construtor padrão
        /// </summary>
        public Description()
        {

        }

        /// <summary>
        /// Construtor com parâmetros
        /// </summary>
        /// <param name="text"></param>
        /// <param name="language"></param>
        protected Description(string text, Language language)
        {
            Text = text;
            Language = language;
        }
    }
}
