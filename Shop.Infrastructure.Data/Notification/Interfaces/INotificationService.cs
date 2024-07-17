using Shop.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Notification.Interfaces
{
    public interface INotificationService<TModel> where TModel : class
    {
        public Task<NotificationResult> Send(TModel model);
    }
}
