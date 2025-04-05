using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.Interfaces.Repositories.Base;
using Giro.Animes.Domain.Interfaces.Services.Base;

namespace Giro.Animes.Domain.Services.Base
{
    public class DomainServiceBase<TRepository, TEntity> : IDomainServiceBase
        where TRepository : IBaseRepository<TEntity>
        where TEntity : EntityBase
    {
        protected readonly TRepository _repository;
        public DomainServiceBase(TRepository repository)
        {
            _repository = repository;
        }
    }
}
