using LogisticsPlatform.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsPlatform.Infrastructure.Services
{
    public class NotificationServices : INotificationServices
    {
        public Task PublishAsync(Guid orderId, double latitude, double longitude)
        {
            // Implementación de la notificacion a los clientes suscritos
            return Task.CompletedTask;
        }
    }
}
