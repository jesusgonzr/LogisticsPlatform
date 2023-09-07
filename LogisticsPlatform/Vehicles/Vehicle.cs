using LogisticsPlatform.Commons;
using LogisticsPlatform.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsPlatform.Vehicles
{
    public class Vehicle : Entity, IAggregateRoot
    {
        private List<Order> orderItems;
        private List<Location> locations;


        public Vehicle(Guid id)
            : this() => Id = id;

        public Vehicle()
        {
            if (Id == Guid.Empty)
            {
                Id = Guid.NewGuid();
            }
            this.orderItems = new List<Order>();
            this.locations = new List<Location>();
        }

        public IReadOnlyCollection<Order> OrdersItem => this.orderItems;

        public IReadOnlyCollection<Location> Locations => this.locations;

        public void AddOrder(Order order)
        {
            this.orderItems.Add(order);
        }

        public void RemoveOrder(Order order) 
        { 
            this.orderItems.Remove(order);
        }

        public void AddLocation(double latitude, double longitude)
        {
            this.locations.Add(new Location(latitude, longitude));
        }
    }
}
