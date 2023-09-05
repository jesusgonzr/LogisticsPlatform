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
        public Order() 
        { 
            Id = Guid.NewGuid();
            Date = DateTime.Now;
        }

        public Order(DateTime date)
            : this() => Date = date == DateTime.MinValue ? throw new ArgumentNullException(nameof(date)) : date;

        public DateTime Date { get; protected set; }
    }
}
