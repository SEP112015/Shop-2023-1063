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
    public class SmsService : INotificationService<SmsModel>
    {
        public Task<NotificationResult> Send(SmsModel model)
        {
            throw new NotImplementedException();
        }
    }
}
