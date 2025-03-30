using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories.Read;
using Giro.Animes.Infra.Data.Contexts;
using Giro.Animes.Infra.Data.Repositories.Read.Base;

namespace Giro.Animes.Infra.Data.Repositories.Read
{
    public class UserReadRepository : ReadRepositoryBase<User, GiroAnimesReadDbContext>, IUserReadRepository
    {
        public UserReadRepository(GiroAnimesReadDbContext dbContext) : base(dbContext)
        {
        }
    }
}
