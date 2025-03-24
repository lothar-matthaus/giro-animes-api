using Giro.Animes.Domain.Enums.Base;

namespace Giro.Animes.Domain.Enums
{
    public class AccountStatus : Enumeration<AccountStatus, int>
    {
        /// <summary>
        /// Status da conta ativa
        /// </summary>
        public static AccountStatus Active = new AccountStatus(0, "Active");
        /// <summary>
        /// Status da conta inativa
        /// </summary>
        public static AccountStatus Inactive = new AccountStatus(1, "Inactive");
        /// <summary>
        /// Status da conta bloqueada
        /// </summary>
        public static AccountStatus Blocked = new AccountStatus(2, "Blocked");
        /// <summary>
        /// Status da conta deletada
        /// </summary>
        public static AccountStatus Deleted = new AccountStatus(3, "Deleted");
        /// <summary>
        /// Status da conta pendente de confirmação de email
        /// </summary>
        public static AccountStatus EmailNotConfirmed = new AccountStatus(4, "EmailNotConfirmed");
    
        /// <summary>
        /// Construtor da classe AccountStatus que herda de Enumeration
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        private AccountStatus(int id, string name) : base(id, name)
        {
        }
    }
}
