using Giro.Animes.Domain.Entities.Base;

namespace Giro.Animes.Domain.Entities
{
    public abstract class Description : EntityBase
    {
        /// <summary>
        /// Texto da descrição  
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Idetificaddr do idioma da descrição
        /// </summary>
        public long LanguageId { get; private set; }
        /// <summary>
        /// Idioma da descrição
        /// </summary>
        public Language Language { get; private set; }

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
