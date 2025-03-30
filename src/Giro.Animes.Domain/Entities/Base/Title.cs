using Giro.Animes.Domain.Constants;
using Giro.Animes.Domain.ValueObjects;
using System.Text.RegularExpressions;

namespace Giro.Animes.Domain.Entities.Base
{
    public abstract class Title : EntityBase
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
                    ifInvalid: () => Notification.Create(GetType().Name, "Title", string.Format(Message.Validation.General.REQUIRED, "Title")),
                    ifValid: () => _name = value);

                Validate(
                    isInvalidIf: !Regex.IsMatch(Patterns.Anime.TITLE, value),
                    ifInvalid: () => Notification.Create(GetType().Name, "Title", Message.Validation.Anime.TITLE_LENGHT),
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
        /// Construtor padrão para garantir a construção do objeto pelo EntityFramework
        /// </summary>
        public Title()
        {

        }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create
        /// </summary>
        /// <param name="name">Nome do título do anime</param>
        /// <param name="language">Idioma do título</param>
        protected Title(string name, Language language)
        {
            Name = name;
            Language = language;
        }
    }
}
