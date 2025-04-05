using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories.Read;
using Giro.Animes.Domain.Interfaces.Repositories.Write;
using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Domain.Services.Base;
using Giro.Animes.Domain.ValueObjects;

namespace Giro.Animes.Domain.Services
{
    public class UserDomainService : DomainServiceBase<IUserWriteRepository, IUserReadRepository, User>, IUserDomainService
    {
        private readonly IMediaDomainService<Avatar> _mediaDomainService;

        public UserDomainService(IUserWriteRepository writeRepository, IUserReadRepository readRepository, IMediaDomainService<Avatar> mediaDomainService) :
            base(writeRepository, readRepository)
        {
            _mediaDomainService = mediaDomainService;
        }

        public async Task<EntityResult<User>> CreateUser(User user)
        {

            IEnumerable<Notification> notifications = new List<Notification>()
                        .Concat(user.IsValid ? Enumerable.Empty<Notification>() : user.GetErrors())
                        .Concat(user.Account.IsValid ? Enumerable.Empty<Notification>() : user.Account.GetErrors())
                        .Concat(user.Account.Password.IsValid ? Enumerable.Empty<Notification>() : user.Account.Password.GetErrors())
                        .Concat(user.Account.Email.IsValid ? Enumerable.Empty<Notification>() : user.Account.Email.GetErrors())
                        .ToList();

            await _writeRepository.AddAsync(user, CancellationToken.None);
            EntityResult<User> result = EntityResult<User>.Create(user, notifications);

            if (result.IsValid)
            {
                await _writeRepository.Commit();
            }

            return result;
        }

        public async Task<User> GetUserAndAccountById(long userId)
        {
            return await _readRepository.GetByIdAsync(userId, CancellationToken.None);
        }
    }
}
