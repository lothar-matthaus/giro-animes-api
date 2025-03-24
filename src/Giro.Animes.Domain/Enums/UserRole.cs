using Giro.Animes.Domain.Enums.Base;

namespace Giro.Animes.Domain.Enums
{
    public class UserRole : Enumeration<UserRole, int>
    {
        /// <summary>
        /// Role de adminstrador do sistema
        /// </summary>
        public static UserRole Admin = new UserRole(0, "Admin");
        /// <summary>
        /// Role de usuário do sistema comum
        /// </summary>
        public static UserRole User = new UserRole(1, "User");
        /// <summary>
        /// Role de usuário convidado do sistema
        /// </summary>
        public static UserRole Guest = new UserRole(2, "Guest");
        /// <summary>
        /// Role de moderador do sistema 
        /// </summary>
        public static UserRole Moderator = new UserRole(3, "Moderator");
        /// <summary>
        /// Role de publicador de conteúdo do sistema
        /// </summary>
        public static UserRole Publisher = new UserRole(4, "Publisher");

        /// <summary>
        /// Construtor privado para criação de novas instâncias de UserRole 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        private UserRole(int id, string name) : base(id, name) { }
    }
}
