using Giro.Animes.Domain.Enums.Base;

namespace Giro.Animes.Domain.Enums
{
    public class UserPlan : Enumeration<UserPlan, int>
    {
        /// <summary>
        /// Plano Bronze 
        /// </summary>
        public static UserPlan Bronze = new UserPlan(0, "Bronze");
        /// <summary>
        /// Plano Prata
        /// </summary>
        public static UserPlan Silver = new UserPlan(1, "Silver");
        /// <summary>
        /// Plano Ouro
        /// </summary>
        public static UserPlan Gold = new UserPlan(2, "Gold");
        /// <summary>
        /// Plano Platina
        /// </summary>
        public static UserPlan Platinum = new UserPlan(3, "Platinum");

        /// <summary>
        /// Construtor privado para criação de novas instâncias de UserPlan
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        private UserPlan(int id, string name) : base(id, name)
        {
        }
    }
}
