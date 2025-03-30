using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories.Read;
using Giro.Animes.Domain.Interfaces.Repositories.Write;
using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Domain.Services.Base;
using Giro.Animes.Domain.ValueObjects;
using System.Linq;

namespace Giro.Animes.Domain.Services
{
    public class UserDomainService : DomainServiceBase<IUserWriteRepository, IUserReadRepository, User>, IUserDomainService
    {
        private readonly IMediaDomainService<Avatar> _mediaDomainService;

        public UserDomainService(IUserWriteRepository writeRepository, IUserReadRepository readRepository, INotificationService notificationService, IMediaDomainService<Avatar> mediaDomainService) :
            base(writeRepository, readRepository, notificationService)
        {
            _mediaDomainService = mediaDomainService;
        }

        public async Task<User> CreateUser(User user)
        {
            IEnumerable<Notification> notifications = new List<Notification>()
            .Concat(user.IsValid ? Enumerable.Empty<Notification>() : user.GetErrors())
            .Concat(user.Account.IsValid ? Enumerable.Empty<Notification>() : user.Account.GetErrors())
            .Concat(user.Account.Password.IsValid ? Enumerable.Empty<Notification>() : user.Account.Password.GetErrors())
            .Concat(user.Account.Avatar.IsValid ? Enumerable.Empty<Notification>() : user.Account.Avatar.GetErrors())
            .ToList();

            if (notifications.Any())
            {
                await _notificationService.AddNotification(notifications);
                return null;
            }

            //  wait _mediaDomainService.CreateAsync(user.Account.Avatar);


            return await _writeRepository.AddAsync(user, CancellationToken.None);
        }

        public async Task<User> GetUserAndAccountById(long userId)
        {
            return await _readRepository.GetByIdAsync(userId, CancellationToken.None);
        }
    }
}
