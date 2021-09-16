using System.Collections.Generic;
using TesteTecnico.Domain.Core.Notifications;

namespace TesteTecnico.Domain.Core.Interfaces.Services
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);

        void AddNotification(string message);
    }
}