using Giro.Animes.Domain.Enums.Base;

namespace Giro.Animes.Domain.Enums
{
    public class AccountPlan : Enumeration<AccountPlan, int>
    {
        /// <summary>
        /// Plano Bronze 
        /// </summary>
        public static AccountPlan Bronze = new AccountPlan(0, "Bronze");
        /// <summary>
        /// Plano Prata
        /// </summary>
        public static AccountPlan Silver = new AccountPlan(1, "Silver");
        /// <summary>
        /// Plano Ouro
        /// </summary>
        public static AccountPlan Gold = new AccountPlan(2, "Gold");
        /// <summary>
        /// Plano Platina
        /// </summary>
        public static AccountPlan Platinum = new AccountPlan(3, "Platinum");

        /// <summary>
        /// Construtor privado para criação de novas instâncias de UserPlan
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        private AccountPlan(int id, string name) : base(id, name)
        {
        }
    }
}
