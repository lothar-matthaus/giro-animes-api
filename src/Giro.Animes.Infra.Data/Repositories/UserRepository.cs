using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories;
using Giro.Animes.Infra.Data.Contexts;
using Giro.Animes.Infra.Data.Repositories.Base;

namespace Giro.Animes.Infra.Data.Repositories
{
    internal class UserRepository : BaseRepository<User, GiroAnimesDbContext>, IUserRepository
    {
        public UserRepository(GiroAnimesDbContext dbContext) : base(dbContext)
        {
        }
    }
}
