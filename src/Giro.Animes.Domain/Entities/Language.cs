using Giro.Animes.Domain.Constants;
using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.ValueObjects;
using System.Text.RegularExpressions;

namespace Giro.Animes.Domain.Entities
{
    public class Language : EntityBase
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                // Verifica se o nome do idioma é nulo ou vazio e retorna um erro de validação caso contrário
                Validate(
                    isInvalidIf: string.IsNullOrEmpty(value),
                    ifInvalid: () => ValidationError.Create(this.GetType().Name, "Name", string.Format(Message.Validation.General.REQUIRED, "Name")),
                    ifValid: () => _name = value);

                // Verifica se o nome do idioma possui entre 3 e 20 caracteres e retorna um erro de validação caso contrário
                Validate(
                    isInvalidIf: !Regex.IsMatch(Patterns.Language.NAME, value),
                    ifInvalid: () => ValidationError.Create(GetType().Name, "Name", Message.Validation.Language.NAME_LENGHT),
                    ifValid: () => _name = value);
            }
        }

        private string _code;

        public string Code
        {
            get { return _code; }
            set
            {
                // Verifica se o código do idioma é nulo ou vazio e retorna um erro de validação caso contrário
                Validate(
                    isInvalidIf: string.IsNullOrEmpty(value),
                    ifInvalid: () => ValidationError.Create(this.GetType().Name, "Code", string.Format(Message.Validation.General.REQUIRED, "Code")),
                    ifValid: () => _name = value);

                // Verifica se o código do idioma possui 5 caracteres e retorna um erro de validação caso contrário
                Validate(
                    isInvalidIf: !Regex.IsMatch(Patterns.Language.CODE, value),
                    ifInvalid: () => ValidationError.Create(GetType().Name, "Code", Message.Validation.Language.CODE_FORMAT),
                    ifValid: () => _name = value);
            }
        }

        private string _nativeName;

        public string NativeName
        {
            get { return _nativeName; }
            set
            {
                // Verifica se o nome nativo do idioma é nulo ou vazio e retorna um erro de validação caso contrário
                Validate(
                    isInvalidIf: string.IsNullOrEmpty(value),
                    ifInvalid: () => ValidationError.Create(this.GetType().Name, "NativeName", string.Format(Message.Validation.General.REQUIRED, "NativeName")),
                    ifValid: () => _name = value);

                // Verifica se o nome nativo do idioma possui entre 3 e 20 caracteres e retorna um erro de validação caso contrário
                Validate(
                    isInvalidIf: !Regex.IsMatch(Patterns.Language.NATIVE_NAME, value),
                    ifInvalid: () => ValidationError.Create(GetType().Name, "NativeName", Message.Validation.Language.NAME_LENGHT),
                    ifValid: () => _name = value);
            }
        }

        /// <summary>
        /// Coleção de configurações do idioma 
        /// </summary>
        public virtual ICollection<Settings> Settings { get; private set; }

        /// <summary>
        /// Coleção de descrições do idioma
        /// </summary>
        public virtual ICollection<Description> Descriptions { get; private set; }

        /// <summary>
        /// Coleção de títulos do idioma
        /// </summary>
        public virtual ICollection<Title> Titles { get; private set; }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create
        /// </summary>
        /// <param name="name"></param>
        /// <param name="code"></param>
        /// <param name="nativeName"></param>
        private Language(string name, string code, string nativeName)
        {
            Name = name;
            Code = code;
            NativeName = nativeName;
        }

        /// <summary>
        /// Método estático para criar um objeto Language com validações de propriedades e retorno do objeto
        /// </summary>
        /// <param name="name"></param>
        /// <param name="code"></param>
        /// <param name="nativeName"></param>
        /// <returns></returns>
        public static Language Create(string name, string code, string nativeName) => new Language(name, code, nativeName);
    }
}
