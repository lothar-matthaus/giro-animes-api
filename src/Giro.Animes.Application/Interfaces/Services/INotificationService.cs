using Giro.Animes.Domain.Interfaces.Services.Base;
using Giro.Animes.Domain.ValueObjects;

namespace Giro.Animes.Application.Interfaces.Services
{
    public interface INotificationService : IDomainServiceBase
    {
        bool HasNotifications();
        Task AddNotification(Notification notification);
        Task AddNotification(IEnumerable<Notification> notifications);
        Task AddNotification(string message, string context, string property);
        Task<IEnumerable<Notification>> GetNotifications();
    }
}
