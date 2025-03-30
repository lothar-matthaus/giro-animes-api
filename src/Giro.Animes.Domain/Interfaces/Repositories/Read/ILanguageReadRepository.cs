using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories.Read.Base;

namespace Giro.Animes.Domain.Interfaces.Repositories.Read
{
    public interface ILanguageReadRepository : IReadBaseRepository<Language>
    {
        Task<Language> GetLanguageByCode(string code);
        Task<IEnumerable<Language>> GetLanguagesByCodes(params string[] codes);
    }
}
