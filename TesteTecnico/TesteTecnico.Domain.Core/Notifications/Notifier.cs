using System.Collections.Generic;
using System.Linq;
using TesteTecnico.Domain.Core.Interfaces.Services;

namespace TesteTecnico.Domain.Core.Notifications
{
    public class Notifier : INotifier
    {
        private readonly List<Notification> _notifications;

        public Notifier()
        {
            _notifications = new List<Notification>();
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }

        public void AddNotification(string message)
        {
            _notifications.Add(new Notification(message));
        }
    }
}