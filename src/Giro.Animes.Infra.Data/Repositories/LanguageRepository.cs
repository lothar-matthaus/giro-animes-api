using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories;
using Giro.Animes.Infra.Data.Contexts;
using Giro.Animes.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Giro.Animes.Infra.Data.Repositories
{
    public class LanguageRepository : BaseRepository<Language, GiroAnimesDbContext>, ILanguageRepository
    {
        public LanguageRepository(GiroAnimesDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Recupera o idioma a partir do código. 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<Language> GetLanguageByCode(string code)
        {
            IQueryable<Language> query = _dbSet.AsQueryable();
            return await query.AsNoTracking()
                .FirstOrDefaultAsync(language => language.Code.Equals(code))
                .ConfigureAwait(false);  // Evita capturar o contexto de sincronização
        }

        /// <summary>
        /// Recupera os idiomas a partir dos códigos.
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
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
