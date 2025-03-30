using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Services.Base;

namespace Giro.Animes.Domain.Interfaces.Services
{
    public interface IUserDomainService : IDomainServiceBase
    {
        Task<User> GetUserAndAccountById(long userId);
        Task<User> CreateUser(User user);
    }
}
