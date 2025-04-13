using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.Enums;

namespace Giro.Animes.Domain.Entities
{
    public class Permission : EntityBase
    {
        public string Resource { get; private set; }
        public string Action { get; private set; }
        public UserRole Role { get; private set; }

        /// <summary>
        /// Default constructor for EF Core
        /// </summary>
        public Permission() { }

        /// <summary>
        /// Constutor privado para garantir que o objeto só pode ser criado através do método Create
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="action"></param>
        /// <param name="role"></param>
        private Permission(string resource, string action, UserRole role)
        {
            Resource = resource;
            Action = action;
            Role = role;
        }

        public static Permission Create(string resource, string action, UserRole role)
        {
            return new Permission(resource, action, role);
        }
    }
}
