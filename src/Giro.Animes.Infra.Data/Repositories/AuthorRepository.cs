using Giro.Animes.Domain.Common.Filters;
using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Pagination;
using Giro.Animes.Domain.Interfaces.Repositories;
using Giro.Animes.Infra.Data.Contexts;
using Giro.Animes.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Giro.Animes.Infra.Data.Repositories
{
    public class AuthorRepository : BaseRepository<Author, GiroAnimesDbContext>, IAuthorRepository
    {
        public AuthorRepository(GiroAnimesDbContext dbContext) : base(dbContext)
        {
        }

        public Task<(IEnumerable<Author>, int)> GetAllPagedAsync(IPagination<AuthorFilter> param, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async new Task<Author> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            return await _dbSet.Include(author => author.Works)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken).ConfigureAwait(false);
        }
    }
}
