using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.Interfaces.Pagination;

namespace Giro.Animes.Domain.Interfaces.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : EntityBase
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity> GetByIdAsync(long id, CancellationToken cancellationToken);
    }
}
