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

        public async Task<Account> GetAccountByEmail(string email, CancellationToken cancellationToken)
        {
            return await _dbSet.Include(account => account.User).FirstOrDefaultAsync(account => account.Email.Value.Equals(email), cancellationToken).ConfigureAwait(false);
        }

        public async Task<Account> GetAccountByUsername(string username, CancellationToken cancellationToken)
        {
            return await _dbSet.Include(account => account.User).FirstOrDefaultAsync(account => account.User.Name.Equals(username)).ConfigureAwait(false);
        }

        public async Task<bool> UsernameAlreadyExists(string username, CancellationToken cancellationToken)
        {
            return await _dbSet.AnyAsync(account => username.ToLower().Equals(account.User.Name.ToLower()), cancellationToken);
        }
    }
}
