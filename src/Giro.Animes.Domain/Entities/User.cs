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
                        ifInvalid: () => Notification.Create(GetType().Name, "Username", string.Format(Message.Validation.General.REQUIRED, "Username")),
                        ifValid: () => _name = value);

                Validate(
                        isInvalidIf: !Regex.IsMatch(value, Patterns.User.NAME),
                        ifInvalid: () => Notification.Create(GetType().Name, "Username", Message.Validation.User.INVALID_NAME),
                        ifValid: () => _name = value);

                Validate(
                        isInvalidIf: !Regex.IsMatch(value, Patterns.User.NAME_LENGHT),
                        ifInvalid: () => Notification.Create(GetType().Name, "Username", Message.Validation.User.INVALID_NAME_LENGHT),
                        ifValid: () => _name = value);
            }
        }

        /// <summary>
        /// Identificador da imagem de perfil
        /// </summary>
        public Avatar Avatar { get; private set; }

        /// <summary>
        /// Papel do usuário 
        /// </summary>
        public UserRole Role { get; private set; }

        /// <summary>
        /// Plano do usuário
        /// </summary>
        public UserPlan Plan { get; private set; }

        /// <summary>
        /// Identificador da conta do usuário
        /// </summary>
        public long AccountId { get; set; }

        /// <summary>
        /// Conta do usuário
        /// </summary>
        public Account Account { get; private set; }

        /// <summary>
        /// Notas que o usuário deu para um determinado anime
        /// </summary>
        public IEnumerable<Rating> Ratings { get; private set; }

        /// <summary>
        /// Construtor padrão do objeto de entidade
        /// </summary>
        public User()
        {
        }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="user"></param>
        /// <param name="userPlan"></param>
        private User(string userName, UserRole user, UserPlan userPlan)
        {
            Name = userName;
            Role = user;
            Plan = userPlan;
        }

        /// <summary>
        /// Define o avatar do usuário 
        /// </summary>
        /// <param name="avatar"></param>
        public void SetAvatar(Avatar avatar)
        {
            Avatar = avatar;
        }

        /// <summary>
        /// Cria uma instância de User. Utilize este método para garantir a construção do objeto
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="role"></param>
        /// <param name="userPlan"></param>
        /// <returns></returns>
        public static User Create(string userName, UserRole role, UserPlan userPlan) => new User(userName, role, userPlan);

    }
}
