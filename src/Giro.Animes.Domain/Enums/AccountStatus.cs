using Giro.Animes.Domain.Enums.Base;

namespace Giro.Animes.Domain.Enums
{
    public class AccountStatus : Enumeration
    {
        /// <summary>
        /// Status da conta ativa
        /// </summary>
        public static AccountStatus Active = new AccountStatus(1, "Active");
        /// <summary>
        /// Status da conta inativa
        /// </summary>
        public static AccountStatus Inactive = new AccountStatus(2, "Inactive");
        /// <summary>
        /// Status da conta bloqueada
        /// </summary>
        public static AccountStatus Blocked = new AccountStatus(3, "Blocked");
        /// <summary>
        /// Status da conta deletada
        /// </summary>
        public static AccountStatus Deleted = new AccountStatus(4, "Deleted");
        /// <summary>
        /// Status da conta pendente de confirmação de email
        /// </summary>
        public static AccountStatus EmailNotConfirmed = new AccountStatus(6, "EmailNotConfirmed");

        private AccountStatus(int id, string name) : base(id, name)
        {
        }
    }
}
