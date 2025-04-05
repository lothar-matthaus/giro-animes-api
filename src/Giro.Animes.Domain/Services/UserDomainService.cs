using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories;
using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Domain.Services.Base;
using Giro.Animes.Domain.ValueObjects;

namespace Giro.Animes.Domain.Services
{
    public class UserDomainService : DomainServiceBase<IUserRepository, User>, IUserDomainService
    {
        public UserDomainService(IUserRepository userRepository) :
            base(userRepository)
        {
        }

        /// <summary>
        /// Creates a new user and validates the user and account.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<EntityResult<User>> CreateUser(User user)
        {

            IEnumerable<Notification> notifications = new List<Notification>()
                        .Concat(user.IsValid ? Enumerable.Empty<Notification>() : user.GetErrors())
                        .Concat(user.Account.IsValid ? Enumerable.Empty<Notification>() : user.Account.GetErrors())
                        .Concat(user.Account.Password.IsValid ? Enumerable.Empty<Notification>() : user.Account.Password.GetErrors())
                        .Concat(user.Account.Email.IsValid ? Enumerable.Empty<Notification>() : user.Account.Email.GetErrors())
                        .ToList();

            await _repository.AddAsync(user, CancellationToken.None);
            EntityResult<User> result = EntityResult<User>.Create(user, notifications);

            if (result.IsValid)
            {
                await _repository.Commit();
            }

            return result;
        }

        public async Task<User> GetUserAndAccountById(long userId)
        {
            return await _repository.GetByIdAsync(userId, CancellationToken.None);
        }
    }
}
