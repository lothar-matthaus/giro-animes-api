using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.Interfaces.Pagination;
using Giro.Animes.Domain.Interfaces.Repositories.Read.Base;
using Microsoft.EntityFrameworkCore;

namespace Giro.Animes.Infra.Data.Repositories.Read.Base
{
    public class ReadRepositoryBase<TEntity, TDbContext> : IReadBaseRepository<TEntity> where TEntity : EntityBase where TDbContext : DbContext
    {
        protected readonly DbSet<TEntity> _dbSet;

        public ReadRepositoryBase(TDbContext dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbSet.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetAllPagedAsync(IPagination param, CancellationToken cancellationToken)
        {
            IQueryable<TEntity> query = _dbSet.AsQueryable();
            param.Count = query.Count();
            IEnumerable<TEntity> result = await query.OrderBy(entity => entity.Id).Skip((param.Page - 1) * param.RowsPerPage).Take(param.RowsPerPage).ToListAsync();
            return result;
        }

        public async Task<TEntity> GetByIdAsync(long id, CancellationToken cancellationToken) => await _dbSet.FindAsync(id, cancellationToken);
    }
}
