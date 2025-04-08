using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Pagination;
using Giro.Animes.Domain.Interfaces.Repositories;
using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Domain.Services.Base;

namespace Giro.Animes.Domain.Services
{
    public class AnimeDomainService : DomainServiceBase<IAnimeRepository, Anime>, IAnimeDomainService
    {
        public AnimeDomainService(IAnimeRepository repository) : base(repository)
        {
        }

        public async Task<(IEnumerable<Anime>, int)> GetAllPagedAsync(IPagination pagination, CancellationToken cancellationToken)
        {
            return await _repository.GetAllPagedAsync(pagination, cancellationToken);
        }

        public async Task<Anime> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(id, cancellationToken);
        }
    }
}
