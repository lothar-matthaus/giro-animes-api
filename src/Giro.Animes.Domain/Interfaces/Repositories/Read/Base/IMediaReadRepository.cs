using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Domain.Interfaces.Repositories.Read.Base
{
    public interface IMediaReadRepository<TMedia> : IReadBaseRepository<TMedia> where TMedia : Media
    {
    }
}
