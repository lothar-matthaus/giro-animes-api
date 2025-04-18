using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories.Base;

namespace Giro.Animes.Domain.Interfaces.Repositories
{
    public interface IGenreRepository : IBaseRepository<Genre>
    {
        Task<IEnumerable<Genre>> GetAllByIdsAsync(IEnumerable<long> ids, CancellationToken cancellationToken);
    }
}
