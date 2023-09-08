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
        private List<Order> orders;
        private List<Location> locations;


        public Vehicle(Guid id)
            : this() => Id = id;

        public Vehicle()
        {
            if (Id == Guid.Empty)
            {
                Id = Guid.NewGuid();
            }
            this.orders = new List<Order>();
            this.locations = new List<Location>();
        }

        public IReadOnlyCollection<Order> Orders => this.orders;

        public IReadOnlyCollection<Location> Locations => this.locations;

        public void AddOrder(Order order)
        {
            this.orders.Add(order);
        }

        public void RemoveOrder(Order order) 
        { 
            this.orders.Remove(order);
        }

        public void AddLocation(double latitude, double longitude)
        {
            this.locations.Add(new Location(latitude, longitude));
        }
    }
}
