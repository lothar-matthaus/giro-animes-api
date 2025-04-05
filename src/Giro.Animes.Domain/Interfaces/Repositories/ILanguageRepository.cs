using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories.Base;

namespace Giro.Animes.Domain.Interfaces.Repositories
{
    public interface ILanguageRepository : IBaseRepository<Language>
    {
        Task<Language> GetLanguageByCode(string code);
        Task<IEnumerable<Language>> GetLanguagesByCodes(params string[] codes);
    }
}
