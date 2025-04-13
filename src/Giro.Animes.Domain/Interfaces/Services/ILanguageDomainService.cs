using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Services.Base;

namespace Giro.Animes.Domain.Interfaces.Services
{
    public interface ILanguageDomainService : IDomainServiceBase
    {
        Task<Language> GetLanguageByCode(string code = "en-US");
        Task<IEnumerable<Language>> GetLanguagesByCodes(params string[] languageCodes);

        Task<Language> GetLanguageByIdAsync(long languageId, CancellationToken cancellationToken);
        Task<IEnumerable<Language>> GetLanguagesByIdsAsync(IEnumerable<long> favoriteLanguages, CancellationToken cancellationToken);
    }
}
