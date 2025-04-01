using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Services.Base;
using Giro.Animes.Domain.ValueObjects;

namespace Giro.Animes.Domain.Interfaces.Services
{
    public interface IUserDomainService : IDomainServiceBase
    {
        Task<User> GetUserAndAccountById(long userId);
        Task<EntityResult<User>> CreateUser(User user);
    }
}
