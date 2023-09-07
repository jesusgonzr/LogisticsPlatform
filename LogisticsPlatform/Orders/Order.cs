using LogisticsPlatform.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsPlatform.Orders
{
    public class Order : Entity, IAggregateRoot
    {
        public Order() : this(Guid.NewGuid(), DateTime.Now) { }

        public Order(DateTime date) : this(Guid.NewGuid(), date) { }

        public Order(Guid id, DateTime date)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            Date = date == DateTime.MinValue ? throw new ArgumentNullException(nameof(date)) : date;
        }

        public DateTime Date { get; protected set; }
    }
}
