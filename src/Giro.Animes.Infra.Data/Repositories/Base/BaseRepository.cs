using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Giro.Animes.Infra.Data.Repositories.Base
{
    public class BaseRepository<TEntity, TDbContext> : IBaseRepository<TEntity> where TEntity : EntityBase where TDbContext : DbContext
    {
        /// <summary>
        /// DbSet for the entity type
        /// </summary>
        /// 
        protected readonly DbSet<TEntity> _dbSet;

        /// <summary>
        /// Base repository constructor
        /// </summary>
        /// <param name="dbContext"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public BaseRepository(TDbContext dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
        }

        /// <summary>
        /// Add an entity to the database
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
        }

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(TEntity entity) => _dbSet.Remove(entity);

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbSet.ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Get an entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<TEntity> GetByIdAsync(long id, CancellationToken cancellationToken) => await _dbSet.FindAsync(id, cancellationToken);

        /// <summary>
        /// Update an entity 
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity) => _dbSet.Update(entity);
    }
}
