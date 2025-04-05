using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Domain.Interfaces.Repositories.Base
{
    public interface IMediaRepository<TMedia> : IBaseRepository<TMedia> where TMedia : Media
    {
    }
}
