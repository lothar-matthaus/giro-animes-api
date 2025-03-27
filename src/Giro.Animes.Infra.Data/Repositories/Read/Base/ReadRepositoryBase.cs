using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.Interfaces.Repositories.Read.Base;
using Giro.Animes.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Giro.Animes.Infra.Data.Repositories.Read.Base
{
    public class ReadRepositoryBase<TEntity> : IReadBaseRepository<TEntity> where TEntity : EntityBase, new()
    {
        private readonly DbSet<TEntity> _dbSet;

        public ReadRepositoryBase(GiroAnimesReadDbContext dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken) => await _dbSet.ToListAsync(cancellationToken);
        public async Task<TEntity> GetByIdAsync(long id, CancellationToken cancellationToken) => await _dbSet.FindAsync(id, cancellationToken);
    }
}
