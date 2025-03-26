using Giro.Animes.Domain.Constants;
using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.ValueObjects;
using System.Text.RegularExpressions;

namespace Giro.Animes.Domain.Entities
{
    public class Language : EntityBase
    {
        /// <summary>
        /// Language name
        /// </summary>
        #region Name
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                // Checks if the language name is null or empty and returns a validation error if so
                Validate(
                    isInvalidIf: string.IsNullOrEmpty(value),
                    ifInvalid: () => ValidationError.Create(this.GetType().Name, "Name", string.Format(Message.Validation.General.REQUIRED, "Name")),
                    ifValid: () => _name = value);

                // Checks if the language name has between 3 and 20 characters and returns a validation error if not
                Validate(
                    isInvalidIf: !Regex.IsMatch(Patterns.Language.NAME, value),
                    ifInvalid: () => ValidationError.Create(GetType().Name, "Name", Message.Validation.Language.NAME_LENGHT),
                    ifValid: () => _name = value);
            }
        }
        #endregion

        /// <summary>
        /// Language code
        /// </summary>
        #region Code
        private string _code;
        public string Code
        {
            get { return _code; }
            set
            {
                // Checks if the language code is null or empty and returns a validation error if so
                Validate(
                    isInvalidIf: string.IsNullOrEmpty(value),
                    ifInvalid: () => ValidationError.Create(this.GetType().Name, "Code", string.Format(Message.Validation.General.REQUIRED, "Code")),
                    ifValid: () => _code = value);

                // Checks if the language code has 5 characters and returns a validation error if not
                Validate(
                    isInvalidIf: !Regex.IsMatch(Patterns.Language.CODE, value),
                    ifInvalid: () => ValidationError.Create(GetType().Name, "Code", Message.Validation.Language.CODE_FORMAT),
                    ifValid: () => _code = value);
            }
        }
        #endregion

        /// <summary>
        /// Native name of the language
        /// </summary>
        #region NativeName
        /// <summary>
        /// Native name of the language
        /// </summary>
        private string _nativeName;


        public string NativeName
        {
            get { return _nativeName; }
            set
            {
                // Checks if the native name of the language is null or empty and returns a validation error if so
                Validate(
                    isInvalidIf: string.IsNullOrEmpty(value),
                    ifInvalid: () => ValidationError.Create(this.GetType().Name, "NativeName", string.Format(Message.Validation.General.REQUIRED, "NativeName")),
                    ifValid: () => _nativeName = value);

                // Checks if the native name of the language has between 3 and 20 characters and returns a validation error if not
                Validate(
                    isInvalidIf: !Regex.IsMatch(Patterns.Language.NATIVE_NAME, value),
                    ifInvalid: () => ValidationError.Create(GetType().Name, "NativeName", Message.Validation.Language.NAME_LENGHT),
                    ifValid: () => _nativeName = value);
            }
        }
        #endregion

        #region Navigation
        /// <summary>
        /// Collection of language settings
        /// </summary>
        public ICollection<Settings> Settings { get; private set; }
        public ICollection<EpisodeTitle> EpisodeTitles { get; private set; }
        public ICollection<GenreTitle> GenreTitles { get; private set; }
        public ICollection<GenreDescription> GenreDescriptions { get; private set; }
        public ICollection<Sinopse> Sinopses { get; private set; }
        public ICollection<Cover> Covers { get; private set; }
        /// <summary>
        /// Collection of language descriptions
        /// </summary>
        // public ICollection<Description> Descriptions { get; private set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Private constructor with parameters. Ensures object construction through the Create method
        /// </summary>
        /// <param name="name">Language name</param>
        /// <param name="code">Language code</param>
        /// <param name="nativeName">Native name of the language</param>
        private Language(string name, string code, string nativeName)
        {
            Name = name;
            Code = code;
            NativeName = nativeName;
        }

        /// <summary>
        /// Static method to create a Language object with property validations and return the object
        /// </summary>
        /// <param name="name">Language name</param>
        /// <param name="code">Language code</param>
        /// <param name="nativeName">Native name of the language</param>
        /// <returns>New instance of Language</returns>
        public static Language Create(string name, string code, string nativeName) => new Language(name, code, nativeName);
        #endregion
    }
}
