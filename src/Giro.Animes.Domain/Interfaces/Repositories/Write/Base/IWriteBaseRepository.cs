using Giro.Animes.Domain.Entities.Base;

namespace Giro.Animes.Domain.Interfaces.Repositories.Write.Base
{
    public interface IWriteBaseRepository<TEntity> where TEntity : EntityBase
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
