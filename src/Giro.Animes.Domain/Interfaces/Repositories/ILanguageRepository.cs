using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories.Base;

namespace Giro.Animes.Domain.Interfaces.Repositories
{
    public interface ILanguageRepository : IBaseRepository<Language>
    {
        Task<Language> GetLanguageByCode(string code = "en-US");
        Task<IEnumerable<Language>> GetLanguagesByCodes(params string[] codes);
        Task<IEnumerable<Language>> GetLanguagesByIdsAsync(IEnumerable<long> ids, CancellationToken cancellationToken);
        Task<Language> GetLanguageByIdAsync(long languageId, CancellationToken cancellationToken);
    }
}
