using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories;
using Giro.Animes.Infra.Data.Contexts;
using Giro.Animes.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Giro.Animes.Infra.Data.Repositories
{
    internal class UserRepository : BaseRepository<User, GiroAnimesDbContext>, IUserRepository
    {
        public UserRepository(GiroAnimesDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> EmailAlreadyExists(string email, CancellationToken cancellationToken)
        {
            return await _dbSet.AnyAsync(x => x.Account.Email.Value == email, cancellationToken);
        }

        public async Task<bool> UsernameAlreadyExists(string username, CancellationToken cancellationToken)
        {
            return await _dbSet.AnyAsync(x => x.Name == username, cancellationToken);
        }
    }
}
