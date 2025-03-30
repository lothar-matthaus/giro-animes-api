using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Domain.ValueObjects;
using Giro.Animes.Domain.ValueObjects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Services
{
    public class NotificationService : INotificationService
    {
        private List<Notification> _notifications;

        public Task AddNotification(Notification notification)
        {
            _notifications ??= new List<Notification>();
            _notifications.Add(notification);

            return Task.CompletedTask;
        }

        public Task AddNotification(IEnumerable<Notification> notifications)
        {
            _notifications ??= new List<Notification>();
            _notifications.AddRange(notifications);

            return Task.CompletedTask;
        }

        public Task AddNotification(string message, string context, string property)
        {
            _notifications ??= new List<Notification>();
            _notifications.Add(Notification.Create(context, property, message));
            
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Notification>> GetNotifications()
        {
            return Task.FromResult(_notifications.AsEnumerable());
        }

        public Task<bool> HasNotifications()
        {
            return Task.FromResult(_notifications?.Any() ?? false);
        }
    }
}
