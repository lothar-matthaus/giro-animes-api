using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories;
using Giro.Animes.Infra.Data.Contexts;
using Giro.Animes.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Infra.Data.Repositories
{
    internal class GenreRepository : BaseRepository<Genre, GiroAnimesDbContext>, IGenreRepository
    {
        public GenreRepository(GiroAnimesDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Genre>> GetAllByIdsAsync(IEnumerable<long> ids, CancellationToken cancellationToken)
        {
            return await _dbSet.Where(genre => ids.Contains(genre.Id.Value)).ToListAsync(cancellationToken);
        }
    }
}
