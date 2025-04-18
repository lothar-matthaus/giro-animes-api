using Giro.Animes.Domain.Entities.Base;

namespace Giro.Animes.Domain.Entities.Joint
{
    public class UserPermission : EntityBase
    {
        public long? UserId { get; set; }
        public long PermissionId { get; set; }
        public virtual User User { get; set; }
        public virtual Permission Permission { get; set; }

        public UserPermission()
        {

        }
    }
}
