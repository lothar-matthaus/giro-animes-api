using Giro.Animes.Domain.Constants;
using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.ValueObjects;
using System.Text.RegularExpressions;

namespace Giro.Animes.Domain.Entities
{
    public class Title : EntityBase
    {
        /// <summary>
        /// Título do anime
        /// </summary>
        private string _name;

        /// <summary>
        /// Título do anime
        /// </summary>
        public string Name
        {
            get { return _name; }
            private set
            {
                Validate(
                    isInvalidIf: string.IsNullOrEmpty(value),
                    ifInvalid: () => ValidationError.Create(this.GetType().Name, "Title", string.Format(Message.Validation.General.REQUIRED, "Title")),
                    ifValid: () => _name = value);

                Validate(
                    isInvalidIf: !Regex.IsMatch(Patterns.Anime.TITLE, value),
                    ifInvalid: () => ValidationError.Create(this.GetType().Name, "Title", Message.Validation.Anime.TITLE_LENGHT),
                    ifValid: () => _name = value);
            }
        }

        /// <summary>
        /// Identificador do idioma
        /// </summary>
        public long LanguageId { get; private set; }

        /// <summary>
        /// Idioma do título
        /// </summary>
        public Language Language { get; private set; }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create
        /// </summary>
        /// <param name="name">Nome do título do anime</param>
        /// <param name="language">Idioma do título</param>
        /// <param name="creationDate">Data de criação do título</param>
        private Title(string name, Language language, DateTime creationDate) : base(creationDate)
        {
            Name = name;
            Language = language;
        }

        /// <summary>
        /// Cria uma instância de Title. Utilize este método para garantir a construção do objeto
        /// </summary>
        /// <param name="name"></param>
        /// <param name="language"></param>
        /// <param name="creationDate"></param>
        /// <returns></returns>
        public static Title Create(string name, Language language, DateTime creationDate) => new Title(name, language, creationDate);
    }
}
