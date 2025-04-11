namespace Giro.Animes.Application.DTOs.Base
{
    public abstract class SimpleDescriptionDTO : BaseSimpleDTO
    {
        /// <summary>
        /// Texto da descrição.
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Idioma da descrição.
        /// </summary>
        public SimpleLanguageDTO Language { get; private set; }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="language"></param>
        /// <param name="id"></param>
        protected SimpleDescriptionDTO(string text, SimpleLanguageDTO language, long? id)
            : base(id)
        {
            Text = text;
            Language = language;
        }
    }
}
