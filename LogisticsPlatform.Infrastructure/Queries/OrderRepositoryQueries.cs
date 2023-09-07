using LogisticsPlatform.Application.Interfaces;
using LogisticsPlatform.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsPlatform.Infrastructure.Queries
{
    public class OrderRepositoryQueries : IOrderRepositoryQueries
    {
        private readonly LogisticsPlatformContext context;

        public OrderRepositoryQueries(LogisticsPlatformContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Order> GetAll()
        {
            return this.context.Orders.ToList();
        }
    }
}
