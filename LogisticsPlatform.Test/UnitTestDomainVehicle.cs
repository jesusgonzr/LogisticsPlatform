using LogisticsPlatform.Vehicles;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace LogisticsPlatform.Test
{
    public class UnitTestDomainVehicle
    {
        private readonly ITestOutputHelper output;

        public UnitTestDomainVehicle(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void NewVehicle()
        {
            // Objeto vehiculo
            var result = new Vehicle();

            // Check result.
            Assert.NotNull(result);

            this.output.WriteLine(JsonConvert.SerializeObject(result));
        }

        [Fact]
        public void AddOrderVehicle()
        {
            var result = new Vehicle();
            result.AddOrder(new Orders.Order());
            
            Assert.NotNull(result);
            Assert.True(result.OrdersItem.Count == 1);

            this.output.WriteLine(JsonConvert.SerializeObject(result));
        }

        [Fact]
        public void RemoveOrderVehicle()
        {
            var result = new Vehicle();
            result.AddOrder(new Orders.Order());
            result.AddOrder(new Orders.Order());
            result.AddOrder(new Orders.Order());

            Assert.NotNull(result);
            Assert.True(result.OrdersItem.Count == 3);
            this.output.WriteLine(JsonConvert.SerializeObject(result));

            var removeOrder = result.OrdersItem.FirstOrDefault();
            Assert.NotNull(removeOrder);
            result.RemoveOrder(removeOrder);
            Assert.True(result.OrdersItem.Count == 2);
            this.output.WriteLine(JsonConvert.SerializeObject(result));

        }

        [Theory]
        [InlineData(40.372205256191414, -3.701859115647144)]
        [InlineData(40.3732514934175, -3.7114721521719782)]
        [InlineData(40.37658626616777, -3.715849517018108)]
        public void AddPositionsVehicle(double latitude, double longitude)
        {
            var result = new Vehicle();
            result.AddOrder(new Orders.Order());
            result.AddLocation(latitude, longitude);

            Assert.NotNull(result);
            Assert.True(result.Locations.Count == 1);

            this.output.WriteLine(JsonConvert.SerializeObject(result));
        }

        [Fact]
        public void PositionsHistoyVehicle()
        {
            var result = new Vehicle();
            result.AddOrder(new Orders.Order());
            result.AddLocation(40.372205256191414, -3.701859115647144);
            result.AddLocation(40.3732514934175, -3.7114721521719782);
            result.AddLocation(40.37658626616777, -3.715849517018108);

            Assert.NotNull(result);
            Assert.True(result.Locations.Count == 3);

            this.output.WriteLine(JsonConvert.SerializeObject(result));
        }
    }
}