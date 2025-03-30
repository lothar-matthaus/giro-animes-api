using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.Interfaces.Repositories.Write.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Giro.Animes.Infra.Data.Repositories.Write.Base
{
    public class WriteRepositoryBase<TEntity, TDbContext> : IWriteBaseRepository<TEntity> where TEntity : EntityBase where TDbContext : DbContext
    {
        private readonly DbSet<TEntity> _dbSet;

        public WriteRepositoryBase(TDbContext dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            EntityEntry entry = await _dbSet.AddAsync(entity, cancellationToken);

            return (TEntity)entry.Entity;
        }

        public void Delete(TEntity entity) => _dbSet.Remove(entity);
        public void Update(TEntity entity) => _dbSet.Update(entity);
    }
}
