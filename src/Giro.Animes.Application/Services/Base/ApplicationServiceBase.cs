using Giro.Animes.Application.Interfaces.Services.Base;
using Giro.Animes.Domain.Interfaces.Services.Base;
using Giro.Animes.Infra.Interfaces;

namespace Giro.Animes.Application.Services.Base
{
    public class ApplicationServiceBase<TDomainService> : IApplicationServiceBase where TDomainService : IDomainServiceBase
    {
        protected readonly IApplicationUser _applicationUser;
        protected readonly TDomainService _domainService;
        public ApplicationServiceBase(IApplicationUser applicationUser, TDomainService domainService)
        {
            _applicationUser = applicationUser;
            _domainService = domainService;
        }
    }
}
