using Microsoft.EntityFrameworkCore;

namespace Giro.Animes.Infra.Data.Contexts
{
    public class GiroAnimesReadDbContext : GiroAnimesWriteDbContext
    {
        public GiroAnimesReadDbContext(DbContextOptions<GiroAnimesWriteDbContext> options, IServiceProvider serviceProvider) : base(options, serviceProvider)
        {
        }
    }
}
