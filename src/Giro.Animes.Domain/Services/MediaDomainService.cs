using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories.Read.Base;
using Giro.Animes.Domain.Interfaces.Repositories.Write.Base;
using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Domain.Services.Base;

namespace Giro.Animes.Domain.Services
{
    public class MediaDomainService<IMediaWriteRepository, IMediaReadRepository, TMedia> : DomainServiceBase<IMediaWriteRepository, IMediaReadRepository, TMedia>, IMediaDomainService<TMedia>
        where TMedia : Media
        where IMediaWriteRepository : IWriteBaseRepository<TMedia>
        where IMediaReadRepository : IReadBaseRepository<TMedia>
    {
        public MediaDomainService(IMediaWriteRepository writeRepository, IMediaReadRepository readRepository, INotificationService notificationService) : 
            base(writeRepository, readRepository, notificationService)
        {
        }

        public async Task<TMedia> CreateAsync(TMedia media)
        {
            if (media.File is null)
                return null;

            return media;
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
