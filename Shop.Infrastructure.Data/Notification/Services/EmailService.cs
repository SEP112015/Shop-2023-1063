using Shop.Infrastructure.Base;
using Shop.Infrastructure.Notification.Interfaces;
using Shop.Infrastructure.Notification.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Notification.Services
{
    public class EmailService : INotificationService<EmailModel>
    {
        public Task<NotificationResult> Send(EmailModel model)
        {
            throw new NotImplementedException();
        }
    }
}
