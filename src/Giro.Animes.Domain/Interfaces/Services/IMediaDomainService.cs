using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Services.Base;

namespace Giro.Animes.Domain.Interfaces.Services
{
    public interface IMediaDomainService<TMedia> : IDomainServiceBase where TMedia : Media
    {
        Task<TMedia> CreateAsync(TMedia media);
        Task<TMedia> UpdateAsync(TMedia media);
        Task DeleteAsync(TMedia media);
        Task<TMedia> GetByIdAsync(long id);
    }
}
