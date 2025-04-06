using Giro.Animes.Domain.Constants;
using Giro.Animes.Domain.ValueObjects.Base;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Giro.Animes.Domain.ValueObjects
{
    public record Password : ValueObjectBase
    {
        /// <summary>
        /// Senha em texto puro
        /// </summary>
        #region PlainText
        private string _plainText;
        public string PlainText
        {
            get { return _plainText; }
            private set
            {
                Validate(
                    isInvalidIf: string.IsNullOrWhiteSpace(value),
                    ifInvalid: () => Notification.Create(GetType().Name, "Senha", string.Format(Message.Validation.General.REQUIRED, "Senha")),
                    ifValid: () => _plainText = value);

                Validate(
                    isInvalidIf: !Regex.IsMatch(value, Patterns.Account.PASSWORD),
                    ifInvalid: () => Notification.Create(GetType().Name, "Senha", Message.Validation.Account.INVALID_PASSWORD),
                    ifValid: () => _plainText = value);

            }
        }
        #endregion

        /// <summary>
        /// Confirmação da senha em texto puro
        /// </summary>
        #region PlainText Confirm
        private string _plainTextConfirm;

        public string PlainTextConfirm
        {
            get { return _plainTextConfirm; }
            private set
            {
                Validate(
                    isInvalidIf: string.IsNullOrWhiteSpace(value),
                    ifInvalid: () => Notification.Create(this.GetType().Name, "Confirmar senha", string.Format(Message.Validation.Account.INVALID_PASSWORD, "Confirmar senha")),
                    ifValid: () => _plainTextConfirm = value);

                Validate(
                    isInvalidIf: !string.Equals(value, _plainText),
                    ifInvalid: () => Notification.Create(this.GetType().Name, "Confirmar senha", Message.Validation.Account.INVALID_PASSWORD_CONFIRM),
                    ifValid: () => _plainTextConfirm = value);
            }
        }
        #endregion

        /// <summary>
        /// Senha com hash de segurança para armazenamento seguro no banco de dados
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Salt do hash da senha para armazenamento seguro no banco de dados
        /// </summary>
        public string Salt { get; init; }

        /// <summary>
        /// Construtor padrão do objeto de valor
        /// </summary>
        public Password()
        {
        }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="plainTextConfirm"></param>
        private Password(string plainText, string plainTextConfirm)
        {
            Salt = GenerateSalt();
            PlainText = plainText;
            PlainTextConfirm = plainTextConfirm;
            Value = GeneratePasswordHash(plainText, Salt);
        }

        #region Behaviors
        /// <summary>
        /// Verifica se a senha informada é válida
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public bool VerifyPassword(string password, string salt)
        {
            return GeneratePasswordHash(password, salt) == Value;
        }

        #endregion

        #region Métodos de hash

        /// <summary>
        /// Gera um salt seguro para hash de senha
        /// </summary>
        /// <returns></returns>
        private string GenerateSalt()
        {
            byte[] saltBytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        /// <summary>
        /// Gera um hash de senha seguro para armazenamento no banco de dados
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        private string GeneratePasswordHash(string password, string salt)
        {
            using (var algorithm = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), 20000, HashAlgorithmName.SHA256))
            {
                return Convert.ToBase64String(algorithm.GetBytes(256 / 8));
            }
        }

        #endregion

        /// <summary>
        /// Cria uma instância de Password. Utilize este método para garantir a construção do objeto de valor
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="plainTextConfirm"></param>
        /// <returns></returns>
        public static Password Create(string plainText, string plainTextConfirm) => new Password(plainText, plainTextConfirm);
    }
}
