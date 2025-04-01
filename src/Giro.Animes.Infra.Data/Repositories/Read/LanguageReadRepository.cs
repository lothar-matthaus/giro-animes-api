using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories.Read;
using Giro.Animes.Infra.Data.Contexts;
using Giro.Animes.Infra.Data.Repositories.Read.Base;
using Microsoft.EntityFrameworkCore;

namespace Giro.Animes.Infra.Data.Repositories.Read
{
    public class LanguageReadRepository : ReadRepositoryBase<Language, GiroAnimesReadDbContext>, ILanguageReadRepository
    {
        public LanguageReadRepository(GiroAnimesReadDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Language> GetLanguageByCode(string code)
        {
            IQueryable<Language> query = _dbSet.AsQueryable();
            return await query.AsNoTracking()
                .FirstOrDefaultAsync(language => language.Code.Equals(code))
                .ConfigureAwait(false);  // Evita capturar o contexto de sincronização
        }

        public async Task<IEnumerable<Language>> GetLanguagesByCodes(params string[] codes)
        {
            IQueryable<Language> query = _dbSet.AsQueryable();
            return await query
                .Where(language => codes.Contains(language.Code))
                .ToListAsync()
                .ConfigureAwait(false);  // Evita capturar o contexto de sincronização
        }
    }
}
