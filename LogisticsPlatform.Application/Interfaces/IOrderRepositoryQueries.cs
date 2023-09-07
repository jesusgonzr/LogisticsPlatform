using LogisticsPlatform.Orders;

namespace LogisticsPlatform.Application.Interfaces
{
    public interface IOrderRepositoryQueries
    {
        IEnumerable<Order> GetAll();

        Order GetById(Guid id);
    }
}
