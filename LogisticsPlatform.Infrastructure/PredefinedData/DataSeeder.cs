using LogisticsPlatform.Orders;
using LogisticsPlatform.Vehicles;

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
            if (!context.Orders.Any())
            {
                var order1 = new Order(Guid.Parse("151f1b3a-75c3-4830-8979-7c6559c0e713"), DateTime.Parse("01/09/2023"));
                var order2 = new Order(Guid.Parse("c6e7a711-d019-4a41-87dc-e69f5c17622a"), DateTime.Parse("01/09/2023"));
                var order3 = new Order(Guid.Parse("d03e31f4-cecd-47b6-8fef-feef9f53e293"), DateTime.Parse("04/09/2023"));
                var order4 = new Order(Guid.Parse("575226c5-063a-4d06-a29c-7bbb9345f24a"), DateTime.Parse("05/09/2023"));
                var order5 = new Order(Guid.Parse("9dcf6195-b3d8-48d8-9294-c23e080deaf8"), DateTime.Parse("07/09/2023"));

                var orders = new List<Order>() { order1, order2, order3, order4, order5 };

                context.Orders.AddRange(orders);
                context.SaveChanges();

                if (!context.Vehicles.Any())
                {
                    var vehicle1 = new Vehicle(Guid.Parse("562053af-2761-4e9f-b8f6-18ea878c3f09"));
                    var vehicle2 = new Vehicle(Guid.Parse("e43948b2-2f3d-414c-ad6b-3e045ce5942b"));
                    var vehicle3 = new Vehicle(Guid.Parse("a629143c-38de-4ffb-88a7-a54cf3d3722d"));

                    vehicle1.AddOrder(order1);
                    vehicle1.AddOrder(order2);
                    vehicle1.AddOrder(order3);
                    vehicle2.AddOrder(order4);

                    vehicle1.AddLocation(40.372205256191414, -3.701859115647144);
                    vehicle1.AddLocation(40.3732514934175, -3.7114721521719782);
                    vehicle1.AddLocation(40.37658626616777, -3.715849517018108);

                    var vehicles = new List<Vehicle>() { vehicle1, vehicle2, vehicle3 };

                    context.Vehicles.AddRange(vehicles);
                    context.SaveChanges();
                }
            }
        }
    }
}
