using Giro.Animes.Domain.Constants;
using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Domain.ValueObjects;
using System.Text.RegularExpressions;

namespace Giro.Animes.Domain.Entities
{
    public class User : EntityBase
    {
        /// <summary>
        /// Nome do usuário 
        /// </summary>
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                Validate(
                        isInvalidIf: string.IsNullOrWhiteSpace(value),
                        ifInvalid: () => ValidationError.Create(GetType().Name, "Username", string.Format(Message.Validation.General.REQUIRED, "Username")),
                        ifValid: () => _name = value);

                Validate(
                        isInvalidIf: !Regex.IsMatch(Patterns.User.NAME, value),
                        ifInvalid: () => ValidationError.Create(GetType().Name, "Username", Message.Validation.User.INVALID_NAME),
                        ifValid: () => _name = value);

                Validate(
                        isInvalidIf: !Regex.IsMatch(Patterns.User.NAME_LENGHT, value),
                        ifInvalid: () => ValidationError.Create(GetType().Name, "Username", Message.Validation.User.INVALID_NAME_LENGHT),
                        ifValid: () => _name = value);
            }
        }


        /// <summary>
        /// Status do usuário 
        /// </summary>
        public UserStatus Status { get; private set; }

        /// <summary>
        /// Papel do usuário 
        /// </summary>
        public UserRole Role { get; private set; }

        /// <summary>
        /// Conta do usuário
        /// </summary>
        public Account Account { get; private set; }

        /// <summary>
        /// Construtor padrão do objeto de entidade
        /// </summary>
        public User()
        {
        }

        /// <summary>
        /// Construtor com parâmetros privados. Garante a construção do objeto através do método Create
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="status"></param>
        /// <param name="account"></param>
        private User(string userName, UserStatus status, Account account)
        {
            Name = userName;
            Status = status;
            Account = account;
            Role = UserRole.Guest;
        }

        /// <summary>
        /// Cria um objeto de entidade User a partir do nome do usuário, status e conta
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="status"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        public static User Create(string userName, UserStatus status, Account account) => new User(userName, status, account);

    }
}
