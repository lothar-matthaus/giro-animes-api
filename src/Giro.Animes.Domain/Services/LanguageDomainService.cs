using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories.Read;
using Giro.Animes.Domain.Interfaces.Repositories.Write;
using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Domain.Services.Base;

namespace Giro.Animes.Domain.Services
{
    public class LanguageDomainService : DomainServiceBase<ILanguageWriteRepository, ILanguageReadRepository, Language>, ILanguageDomainService
    {
        public LanguageDomainService(ILanguageWriteRepository writeRepository, ILanguageReadRepository readRepository) : base(writeRepository, readRepository)
        {
        }

        public Task<Language> GetLanguageByCode(string code = "en-US")
        {
            return _readRepository.GetLanguageByCode(code);
        }

        public Task<IEnumerable<Language>> GetLanguagesByCodes(params string[] languageCodes)
        {
            return _readRepository.GetLanguagesByCodes(languageCodes);
        }
    }
}
