using Giro.Animes.Domain.Entities.Base;

namespace Giro.Animes.Domain.Interfaces.Repositories.Read.Base
{
    public interface IReadBaseRepository<TEntity> where TEntity : EntityBase, new()
    {
        Task<TEntity> GetByIdAsync(long id, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    }
}
