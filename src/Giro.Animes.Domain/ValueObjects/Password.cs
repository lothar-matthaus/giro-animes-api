using Giro.Animes.Domain.Constants;
using Giro.Animes.Domain.ValueObjects.Base;
using System.Text;
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
            init
            {
                Validate(
                    isInvalidIf: string.IsNullOrEmpty(value),
                    ifInvalid: () => ValidationError.Create(this.GetType().Name, "Senha", string.Format(Message.Validation.General.REQUIRED, "Senha")),
                    ifValid: () => _plainText = value);

                Validate(
                    isInvalidIf: !Regex.IsMatch(Patterns.Account.PASSWORD, value),
                    ifInvalid: () => ValidationError.Create(this.GetType().Name, "Senha", Message.Validation.Account.INVALID_PASSWORD),
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
            init
            {
                Validate(
                    isInvalidIf: string.IsNullOrEmpty(value),
                    ifInvalid: () => ValidationError.Create(this.GetType().Name, "Confirmar senha", string.Format(Message.Validation.Account.INVALID_PASSWORD, "Confirmar senha")),
                    ifValid: () => _plainTextConfirm = value);

                Validate(
                    isInvalidIf: !string.Equals(value, _plainText),
                    ifInvalid: () => ValidationError.Create(this.GetType().Name, "Confirmar senha", Message.Validation.Account.INVALID_PASSWORD),
                    ifValid: () => _plainTextConfirm = value);
            }
        }
        #endregion

        /// <summary>
        /// Senha com hash de segurança para armazenamento seguro no banco de dados
        /// </summary>
        public string Value { get; init; }

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
        public Password(string plainText, string plainTextConfirm)
        {
            _plainText = plainText;
            _plainTextConfirm = plainTextConfirm;
            Salt = GenerateSalt();
            Value = GeneratePasswordHash(plainText, Salt);
        }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create com salt pré-definido
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="plainTextConfirm"></param>
        /// <param name="salt"></param>
        public Password(string plainText, string plainTextConfirm, string salt)
        {
            _plainText = plainText;
            _plainTextConfirm = plainTextConfirm;
            Salt = salt;
            Value = GeneratePasswordHash(plainText, Salt);
        }

        #region Métodos de hash

        /// <summary>
        /// Gera um salt seguro para hash de senha
        /// </summary>
        /// <returns></returns>
        private string GenerateSalt()
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";
            StringBuilder salt = new StringBuilder(16);
            using (var rng = System.Security.Cryptography.RandomNumberGenerator.Create())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (salt.Length < 16)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    salt.Append(validChars[(int)(num % (uint)validChars.Length)]);
                }
            }
            return salt.ToString();
        }

        /// <summary>
        /// Gera um hash de senha seguro para armazenamento no banco de dados
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        private string GeneratePasswordHash(string password, string salt)
        {
            using (var algorithm = new System.Security.Cryptography.Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), 10000, System.Security.Cryptography.HashAlgorithmName.SHA256))
            {
                return Convert.ToBase64String(algorithm.GetBytes(256 / 8));
            }
        }

        /// <summary>
        /// Verifica se a senha informada é válida
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        private bool VerifyPassword(string password, string salt, string hash)
        {
            return GeneratePasswordHash(password, salt) == hash;
        }

        #endregion

        /// <summary>
        /// Cria uma instância de Password. Utilize este método para garantir a construção do objeto de valor
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="plainTextConfirm"></param>
        /// <returns></returns>
        public static Password Create(string plainText, string plainTextConfirm) => new Password(plainText, plainTextConfirm);

        /// <summary>
        /// Cria uma instância de Password com salt pré-definido. Utilize este método para garantir a construção do objeto de valor
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="plainTextConfirm"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static Password Create(string plainText, string plainTextConfirm, string salt) => new Password(plainText, plainTextConfirm, salt);
    }
}
