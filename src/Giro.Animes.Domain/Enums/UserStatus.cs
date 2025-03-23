using Giro.Animes.Domain.Enums.Base;

namespace Giro.Animes.Domain.Enums
{
    public class UserStatus : Enumeration
    {
        /// <summary>
        /// Status do usuário ativo
        /// </summary>
        public static UserStatus Active = new UserStatus(1, "Active");
        /// <summary>
        /// Status do usuário inativo
        /// </summary>
        public static UserStatus Inactive = new UserStatus(2, "Inactive");
        /// <summary>
        /// Status do usuário bloqueado
        /// </summary>
        public static UserStatus Blocked = new UserStatus(3, "Blocked");
        /// <summary>
        /// Status do usuário deletado
        /// </summary>
        public static UserStatus Deleted = new UserStatus(4, "Deleted");

        /// <summary>
        /// Construtor padrão da classe UserStatus 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        private UserStatus(int id, string name) : base(id, name) { }
    }
}
