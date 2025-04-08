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
        public async Task<Language> GetLanguageByCode(string code = "us-EN")
        {
            IQueryable<Language> query = _dbSet.AsQueryable();
            Language language = await query.FirstOrDefaultAsync(language => language.Code == code).ConfigureAwait(false);  // Evita capturar o contexto de sincronização
            return language;
        }

        /// <summary>
        /// Recupera os idiomas a partir dos códigos.
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Language>> GetLanguagesByCodes(params string[] codes)
        {
            IQueryable<Language> query = _dbSet.AsQueryable();
            IEnumerable<Language> result = await query.Where(language => codes.Contains(language.Code) || language.Code == "us-EN").ToListAsync().ConfigureAwait(false);  // Evita capturar o contexto de sincronização
            return result;
        }
    }
}
