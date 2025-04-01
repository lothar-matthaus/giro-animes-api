using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories.Write;
using Giro.Animes.Infra.Data.Repositories.Write.Base;
using Microsoft.EntityFrameworkCore;

namespace Giro.Animes.Infra.Data.Repositories.Write
{
    public class MediaWriteRepository<TMedia, TDbContext> : WriteRepositoryBase<TMedia, TDbContext>, IMediaWriteRepository<TMedia> where TMedia : Media where TDbContext : DbContext
    {
        public MediaWriteRepository(TDbContext dbContext) : base(dbContext)
        {
        }
    }
}
