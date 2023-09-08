namespace LogisticsPlatform.Application.Interfaces
{
    public interface INotificationServices
    {
        Task PublishAsync(Guid orderId, double latitude, double longitude);
    }
}
