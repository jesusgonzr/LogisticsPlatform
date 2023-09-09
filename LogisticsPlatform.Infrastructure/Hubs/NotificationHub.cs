using Microsoft.AspNetCore.SignalR;

namespace LogisticsPlatform.Infrastructure.Hubs
{
    public class NotificationHub : Hub
    {
        public Task TestConnection()
        {
            return this.Clients.All.SendAsync("TestBrodcasting", $"Testing a Basic HUB at {DateTime.Now.ToLocalTime()}");
        }
    }
}
