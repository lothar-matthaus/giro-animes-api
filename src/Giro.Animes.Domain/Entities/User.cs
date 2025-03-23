using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.Enums;

namespace Giro.Animes.Domain.Entities
{
    public class User : EntityBase
    {
        /// <summary>
        /// Nome do usuário 
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// Status do usuário 
        /// </summary>
        public UserStatus Status { get; private set; }

        /// <summary>
        /// Identificador da conta do usuário
        /// </summary>
        public long AccountId { get; private set; }

        /// <summary>
        /// Conta do usuário
        /// </summary>
        public Account Account { get; private set; }

        private User(string userName, UserStatus status, Account account): base(DateTime.Now)
        {
            UserName = userName;
            Status = status;
            Account = account;
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
