using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories.Base;
using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Domain.Services.Base;

namespace Giro.Animes.Domain.Services
{
    public class MediaDomainService<TMediaRepository, TMedia> : DomainServiceBase<TMediaRepository, TMedia>, IMediaDomainService<TMedia>
        where TMedia : Media
        where TMediaRepository : IMediaRepository<TMedia>
    {
        public MediaDomainService(TMediaRepository repository) :
            base(repository)
        {
        }

        public Task<TMedia> CreateAsync(TMedia media)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TMedia media)
        {
            throw new NotImplementedException();
        }

        public Task<TMedia> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<TMedia> UpdateAsync(TMedia media)
        {
            throw new NotImplementedException();
        }
    }
}
