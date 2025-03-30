using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories.Write;
using Giro.Animes.Infra.Data.Contexts;
using Giro.Animes.Infra.Data.Repositories.Write.Base;

namespace Giro.Animes.Infra.Data.Repositories.Write
{
    internal class UserWriteRepository : WriteRepositoryBase<User, GiroAnimesWriteDbContext>, IUserWriteRepository
    {
        public UserWriteRepository(GiroAnimesWriteDbContext dbContext) : base(dbContext)
        {
        }
    }
}
