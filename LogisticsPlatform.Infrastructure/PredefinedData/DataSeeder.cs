using LogisticsPlatform.Orders;
using LogisticsPlatform.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsPlatform.Infrastructure.PredefinedData
{
    public class DataSeeder
    {
        private readonly LogisticsPlatformContext context;

        public DataSeeder(LogisticsPlatformContext context)
        {
            this.context = context;
        }

        public void Seed()
        {
            if (!context.Vehicles.Any())
            {
                var vehicles = new List<Vehicle>()
                {
                    new Vehicle(Guid.Parse("562053af-2761-4e9f-b8f6-18ea878c3f09")),
                    new Vehicle(Guid.Parse("e43948b2-2f3d-414c-ad6b-3e045ce5942b")),
                };

                context.Vehicles.AddRange(vehicles);
                context.SaveChanges();
            }

            if (!context.Orders.Any())
            {
                var orders = new List<Order>()
                {
                    new Order(Guid.Parse("151f1b3a-75c3-4830-8979-7c6559c0e713"), DateTime.Parse("01/09/2023")),
                    new Order(Guid.Parse("c6e7a711-d019-4a41-87dc-e69f5c17622a"), DateTime.Parse("01/09/2023")),
                    new Order(Guid.Parse("d03e31f4-cecd-47b6-8fef-feef9f53e293"), DateTime.Parse("04/09/2023")),
                    new Order(Guid.Parse("575226c5-063a-4d06-a29c-7bbb9345f24a"), DateTime.Parse("05/09/2023")),
                };

                context.Orders.AddRange(orders);
                context.SaveChanges();
            }
        }
    }
}
