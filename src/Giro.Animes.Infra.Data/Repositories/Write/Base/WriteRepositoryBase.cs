using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.Interfaces.Repositories.Write.Base;
using Microsoft.EntityFrameworkCore;

namespace Giro.Animes.Infra.Data.Repositories.Write.Base
{
    public class WriteRepositoryBase<TEntity> : IWriteBaseRepository<TEntity> where TEntity : EntityBase, new()
    {
        private readonly DbSet<TEntity> _dbSet;

        public WriteRepositoryBase(DbContext dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken) => await _dbSet.AddAsync(entity, cancellationToken);
        public void Delete(TEntity entity) => _dbSet.Remove(entity);
        public void Update(TEntity entity) => _dbSet.Update(entity);

    }
}
