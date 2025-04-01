using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Domain.ValueObjects;

namespace Giro.Animes.Application.Services
{
    public class NotificationService : INotificationService
    {
        private List<Notification> _notifications = new List<Notification>();

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

        public bool HasNotifications()
        {
            return _notifications.Any();
        }
    }
}
