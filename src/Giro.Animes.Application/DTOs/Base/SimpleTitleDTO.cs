namespace Giro.Animes.Application.DTOs.Base
{
    public abstract class SimpleTitleDTO : BaseSimpleDTO
    {
        /// <summary>
        /// Nome do título.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Idioma do título.
        /// </summary>
        public SimpleLanguageDTO Language { get; private set; }

        /// <summary>
        /// Construtor privado para o SimpleTitleDTO.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="language"></param>
        /// <param name="id"></param>
        protected SimpleTitleDTO(string name, SimpleLanguageDTO language, long? id) : base(id)
        {
            Name = name;
            Language = language;
        }
    }
}
