using LogisticsPlatform.Orders;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace LogisticsPlatform.Test
{
    public class UnitTestDomainOrder
    {
        private readonly ITestOutputHelper output;

        public UnitTestDomainOrder(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void NewOrder()
        {
            var result = new Order();
            Assert.NotNull(result);

            this.output.WriteLine(JsonConvert.SerializeObject(result));
        }

        [Fact]
        public void NewOrder_Expecific_Date()
        {
            var date = DateTime.Now;
            var result = new Order(date);

            Assert.NotNull(result);
            Assert.True(date == result.Date);

            this.output.WriteLine(JsonConvert.SerializeObject(result));
        }

        [Fact]
        public void NewOrder_Invalid_Date()
        {
            var date = DateTime.MinValue;

            var exception = Assert.Throws<ArgumentNullException>(() => new Order(date));
            Assert.True(exception.Message == "Value cannot be null. (Parameter 'date')");
        }

    }
}