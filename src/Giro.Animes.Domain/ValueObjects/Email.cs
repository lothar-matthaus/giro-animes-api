﻿using Giro.Animes.Domain.Constants;
using Giro.Animes.Domain.ValueObjects.Base;
using System.Text.RegularExpressions;

namespace Giro.Animes.Domain.ValueObjects
{
    public record Email : ValueObjectBase
    {
        #region Value
        private string _value;
        public string Value
        {
            get { return _value; }
            set
            {
                Validate(
                    isInvalidIf: string.IsNullOrEmpty(value),
                    ifInvalid: () => Notification.Create(this.GetType().Name, "E-mail", string.Format(Message.Validation.General.REQUIRED, "E-mail")),
                    ifValid: () => _value = value);

                Validate(
                    isInvalidIf: !Regex.IsMatch(value, Patterns.Account.EMAIL),
                    ifInvalid: () => Notification.Create(this.GetType().Name, "E-mail", string.Format(Message.Validation.General.INVALID, "E-mail")),
                    ifValid: () => _value = value);
            }
        }
        #endregion

        public Email()
        {
        }
        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create
        /// </summary>
        /// <param name="value"></param>
        private Email(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Cria uma instância de Email. Utilize este método para garantir a construção do objeto
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Email Create(string value) => new Email(value);
    }
}
