using Giro.Animes.Domain.Common.Filters;
using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Pagination;
using Giro.Animes.Domain.Interfaces.Repositories;
using Giro.Animes.Infra.Data.Contexts;
using Giro.Animes.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Giro.Animes.Infra.Data.Repositories
{
    public class AnimeRepository : BaseRepository<Anime, GiroAnimesDbContext>, IAnimeRepository
    {
        public AnimeRepository(GiroAnimesDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<(IEnumerable<Anime>, int)> GetAllPagedAsync(IPagination<AnimeFilter> pagination, CancellationToken cancellationToken)
        {
            IQueryable<Anime> query = _dbSet.AsQueryable();

            query = query.Where(anime => anime.Genres.Any(genre => (pagination.Filters.GenreId == null || genre.Id == pagination.Filters.GenreId)) &&
                                         anime.Authors.Any(author => (pagination.Filters.AuthorId == null || author.Id == pagination.Filters.AuthorId)) &&
                                         anime.Titles.Any(title => (string.IsNullOrWhiteSpace(pagination.Filters.Name) || title.Name.ToLower().Contains(pagination.Filters.Name.ToLower()))));

            query = pagination.Filters.OrderByDescending ?
                query.OrderBy(string.Format("{0} {1}", pagination.Filters.SortBy, "DESC")) :
                query.OrderBy(pagination.Filters.SortBy);

            // Obter o total de itens antes da paginação
            int totalItems = await query.CountAsync(cancellationToken);

            // Aplicar paginação
            query = query
                .Skip(pagination.RowsPerPage * (pagination.Page - 1))
                .Take(pagination.RowsPerPage);

            // Executar a consulta e obter os resultados
            IEnumerable<Anime> result = await query.AsNoTracking().ToListAsync(cancellationToken);

            return (result, totalItems);
        }
    }
}
