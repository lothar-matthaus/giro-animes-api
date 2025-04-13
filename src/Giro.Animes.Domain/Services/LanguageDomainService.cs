using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories;
using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Domain.Services.Base;

namespace Giro.Animes.Domain.Services
{
    public class LanguageDomainService : DomainServiceBase<ILanguageRepository, Language>, ILanguageDomainService
    {
        public LanguageDomainService(ILanguageRepository languageRepository) :
            base(languageRepository)
        { }

        public Task<Language> GetLanguageByCode(string code)
        {
            return _repository.GetLanguageByCode(code);
        }

        public async Task<Language> GetLanguageByIdAsync(long languageId, CancellationToken cancellationToken)
        {
            return await _repository.GetLanguageByIdAsync(languageId, cancellationToken);
        }

        public Task<IEnumerable<Language>> GetLanguagesByCodes(params string[] languageCodes)
        {
            return _repository.GetLanguagesByCodes(languageCodes);
        }

        public async Task<IEnumerable<Language>> GetLanguagesByIdsAsync(IEnumerable<long> ids, CancellationToken cancellationToken)
        {
            return await _repository.GetLanguagesByIdsAsync(ids,cancellationToken );
        }
    }
}
