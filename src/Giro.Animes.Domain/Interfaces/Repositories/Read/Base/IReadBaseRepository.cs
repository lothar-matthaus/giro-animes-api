using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.Interfaces.Pagination;

namespace Giro.Animes.Domain.Interfaces.Repositories.Read.Base
{
    public interface IReadBaseRepository<TEntity> where TEntity : EntityBase
    {
        Task<TEntity> GetByIdAsync(long id, CancellationToken cancellationToken);
        Task<(IEnumerable<TEntity>, int)> GetAllPagedAsync(IPagination param, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    }
}
