using LogisticsPlatform.Application.Interfaces;
using LogisticsPlatform.Infrastructure.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsPlatform.Infrastructure.Services
{
    public class NotificationServices : INotificationServices
    {
        private readonly IHubContext<NotificationHub> hubContext;

        public NotificationServices(IHubContext<NotificationHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        public Task PublishAsync(Guid orderId, double latitude, double longitude)
        {
            // Notificar a los clientes suscritos al grupo del pedido
            string message = $"{DateTime.Now} - Latitude: {latitude} - Longitude: {longitude}";
            this.hubContext.Clients.All.SendAsync($"order-{orderId}", message);

            // Implementación de la notificacion a los clientes suscritos
            return Task.CompletedTask;
        }
    }
}
