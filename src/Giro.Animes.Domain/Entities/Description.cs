using Giro.Animes.Domain.Entities.Base;

namespace Giro.Animes.Domain.Entities
{
    public class Description : EntityBase
    {
        /// <summary>
        /// Texto da descrição  
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Idetificaddr do idioma da descrição
        /// </summary>
        public long? LanguageId { get; set; }
        /// <summary>
        /// Idioma da descrição
        /// </summary>
        public Language Language { get; set; }


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
        private Description(string text, Language language) : base(DateTime.Now)
        {
            Text = text;
            Language = language;
        }

        /// <summary>
        /// Cria uma nova descrição
        /// </summary>
        /// <param name="text"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public static Description Create(string text, Language language) => new Description(text, language);
    }
}
