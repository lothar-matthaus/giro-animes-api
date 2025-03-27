using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories.Write;
using Giro.Animes.Infra.Data.Contexts;
using Giro.Animes.Infra.Data.Repositories.Write.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Infra.Data.Repositories.Write
{
    internal class UserWriteRepository : WriteRepositoryBase<User>, IUserWriteRepository
    {
        public UserWriteRepository(GiroAnimesWriteDbContext dbContext) : base(dbContext)
        {
        }
    }
}
