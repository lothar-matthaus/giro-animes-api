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

        public Task<IEnumerable<Language>> GetLanguagesByCodes(params string[] languageCodes)
        {
            return _repository.GetLanguagesByCodes(languageCodes);
        }
    }
}
