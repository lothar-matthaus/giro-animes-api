using Giro.Animes.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
