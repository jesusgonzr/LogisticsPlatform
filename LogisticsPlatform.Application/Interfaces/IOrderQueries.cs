using LogisticsPlatform.Application.Models;

namespace LogisticsPlatform.Application.Interfaces
{
    public interface IOrderQueries
    {
        IEnumerable<OrderViewModel> GetAll();

        OrderViewModel GetById(Guid id);
    }
}
