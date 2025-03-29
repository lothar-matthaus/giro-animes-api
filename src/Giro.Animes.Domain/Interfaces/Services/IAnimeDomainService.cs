using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Services.Base;

namespace Giro.Animes.Domain.Interfaces.Services
{
    public interface IAnimeDomainService : IDomainServiceBase
    {
        Task<Anime> CreateNewAnime(Anime anime);
        Task<bool> DeleteAnime(Anime anime);
    }
}
