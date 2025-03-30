using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.Interfaces.Services.Base;
using Giro.Animes.Domain.ValueObjects;
using Giro.Animes.Domain.ValueObjects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Interfaces.Services
{
    public interface INotificationService : IDomainServiceBase
    {
        Task<bool> HasNotifications();
        Task AddNotification(Notification notification);
        Task AddNotification(IEnumerable<Notification> notifications);
        Task AddNotification(string message, string context, string property);
        Task<IEnumerable<Notification>> GetNotifications();
    }
}
