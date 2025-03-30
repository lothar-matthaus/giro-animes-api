using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories.Read.Base;
using Giro.Animes.Infra.Data.Contexts;
using Giro.Animes.Infra.Data.Repositories.Read.Base;
using Microsoft.EntityFrameworkCore;

namespace Giro.Animes.Infra.Data.Repositories.Read
{
    public class MediaReadRepository<TMedia, TDbContext> : ReadRepositoryBase<TMedia, TDbContext>, IMediaReadRepository<TMedia> where TMedia : Media where TDbContext : DbContext
    {
        public MediaReadRepository(TDbContext dbContext) : base(dbContext)
        {
        }
    }
}
