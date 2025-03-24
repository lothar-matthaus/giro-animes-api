using Giro.Animes.Domain.Enums.Base;

namespace Giro.Animes.Domain.Enums
{
    public class UserStatus : Enumeration<UserStatus, int>
    {
        /// <summary>
        /// Status do usuário ativo
        /// </summary>
        public static UserStatus Active = new UserStatus(0, "Active");
        /// <summary>
        /// Status do usuário inativo
        /// </summary>
        public static UserStatus Inactive = new UserStatus(1, "Inactive");
        /// <summary>
        /// Status do usuário bloqueado
        /// </summary>
        public static UserStatus Blocked = new UserStatus(2, "Blocked");
        /// <summary>
        /// Status do usuário deletado
        /// </summary>
        public static UserStatus Deleted = new UserStatus(3, "Deleted");

        /// <summary>
        /// Construtor padrão da classe UserStatus 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        private UserStatus(int id, string name) : base(id, name) { }
    }
}
