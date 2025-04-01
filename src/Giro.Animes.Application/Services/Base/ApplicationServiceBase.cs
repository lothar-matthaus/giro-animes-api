using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Application.Interfaces.Services.Base;
using Giro.Animes.Domain.Interfaces.Services.Base;
using Giro.Animes.Infra.Interfaces;

namespace Giro.Animes.Application.Services.Base
{
    public class ApplicationServiceBase<TDomainService> : IApplicationServiceBase where TDomainService : IDomainServiceBase
    {
        protected readonly IApplicationUser _applicationUser;
        protected readonly TDomainService _domainService;
        protected readonly INotificationService _notificationService;
        public ApplicationServiceBase(IApplicationUser applicationUser, INotificationService notificationService, TDomainService domainService)
        {
            _applicationUser = applicationUser;
            _domainService = domainService;
            _notificationService = notificationService;
        }
    }
}
