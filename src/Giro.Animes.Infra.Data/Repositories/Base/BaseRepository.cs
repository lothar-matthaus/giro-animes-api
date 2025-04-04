﻿using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.Interfaces.Pagination;
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
        /// DbContext for the repository
        /// </summary>
        protected readonly TDbContext _dbContext;

        /// <summary>
        /// Base repository constructor
        /// </summary>
        /// <param name="dbContext"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public BaseRepository(TDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<TEntity>();
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
        /// Commit changes to the database
        /// </summary>
        /// <returns></returns>
        public Task<int> Commit()
        {
            Task<int> key = _dbContext.SaveChangesAsync(CancellationToken.None);
            return key;
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
        /// Get all entities paged
        /// </summary>
        /// <param name="param"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<(IEnumerable<TEntity>, int)> GetAllPagedAsync(IPagination param, CancellationToken cancellationToken)
        {
            IQueryable<TEntity> query = _dbSet.AsQueryable();
            int count = query.Count();
            IEnumerable<TEntity> result = await query.OrderBy(entity => entity.Id).Skip((param.Page - 1) * param.RowsPerPage).Take(param.RowsPerPage).ToListAsync();

            return (result, count);
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
