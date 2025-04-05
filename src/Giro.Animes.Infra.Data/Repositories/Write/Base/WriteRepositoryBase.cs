using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.Interfaces.Repositories.Write.Base;
using Microsoft.EntityFrameworkCore;

namespace Giro.Animes.Infra.Data.Repositories.Write.Base
{
    public class WriteRepositoryBase<TEntity, TDbContext> : IWriteBaseRepository<TEntity> where TEntity : EntityBase where TDbContext : DbContext
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly TDbContext _dbContext;

        public WriteRepositoryBase(TDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
        }

        public Task<int> Commit()
        {
            Task<int> key = _dbContext.SaveChangesAsync(CancellationToken.None);
            return key;
        }

        public void Delete(TEntity entity) => _dbSet.Remove(entity);
        public void Update(TEntity entity) => _dbSet.Update(entity);
    }
}
