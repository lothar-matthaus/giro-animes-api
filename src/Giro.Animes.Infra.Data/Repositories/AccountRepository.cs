using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories;
using Giro.Animes.Infra.Data.Contexts;
using Giro.Animes.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Giro.Animes.Infra.Data.Repositories
{
    internal class AccountRepository : BaseRepository<Account, GiroAnimesDbContext>, IAccountRepository
    {
        public AccountRepository(GiroAnimesDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> EmailAlreadyExists(string email, CancellationToken cancellationToken)
        {
            return await _dbSet.AnyAsync(account => account.Email.Value == email, cancellationToken);
        }

        public Task<Account> GetAccountByEmail(string email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetAccountByUsername(string username, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UsernameAlreadyExists(string username, CancellationToken cancellationToken)
        {
            return await _dbSet.AnyAsync(account => account.User.Name == username, cancellationToken);
        }
    }
}
