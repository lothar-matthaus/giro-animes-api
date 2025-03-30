using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories.Write.Base;

namespace Giro.Animes.Domain.Interfaces.Repositories.Write
{
    public interface IMediaWriteRepository<TMedia> : IWriteBaseRepository<TMedia> where TMedia : Media
    {
    }
}
