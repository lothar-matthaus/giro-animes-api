using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories.Base;
using Giro.Animes.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Giro.Animes.Infra.Data.Repositories
{
    public class MediaRepository<TMedia, TDbContext> : BaseRepository<TMedia, TDbContext>, IMediaRepository<TMedia> where TMedia : Media where TDbContext : DbContext
    {
        public MediaRepository(TDbContext dbContext) : base(dbContext)
        {
        }
    }
}
