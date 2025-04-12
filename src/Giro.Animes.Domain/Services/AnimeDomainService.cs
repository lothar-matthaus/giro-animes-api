using Giro.Animes.Domain.Common.Filters;
using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Pagination;
using Giro.Animes.Domain.Interfaces.Repositories;
using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Domain.Services.Base;
using Giro.Animes.Domain.ValueObjects;

namespace Giro.Animes.Domain.Services
{
    public class AnimeDomainService : DomainServiceBase<IAnimeRepository, Anime>, IAnimeDomainService
    {
        public AnimeDomainService(IAnimeRepository repository) : base(repository)
        {
        }

        public async Task<(IEnumerable<Anime>, int)> GetAllPagedAsync(IPagination<AnimeFilter> pagination, CancellationToken cancellationToken)
        {
            return await _repository.GetAllPagedAsync(pagination, cancellationToken);
        }

        public async Task<Anime> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(id, cancellationToken);
        }

        public async Task<EntityResult<Anime>> IncrementView(long id, CancellationToken cancellationToken)
        {
            Anime anime = await _repository.GetByIdAsync(id, cancellationToken);

            if (anime is null)
                return EntityResult<Anime>.Create(null, new List<Notification> { Notification.Create("Anime", "", "Anime não encontrado") });

            anime.IncrementView();
            _repository.Update(anime);

            return EntityResult<Anime>.Create(anime, null);
        }
}
}
