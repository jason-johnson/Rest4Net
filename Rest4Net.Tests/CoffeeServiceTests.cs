using Rest4Net.Test.Services;
using Xunit;

namespace Rest4Net.Tests
{
    public class CoffeeServiceTests
    {
        [Fact]
        public void TestGetCoffee()
        {
            var service = new CoffeeShop();
            var coffee = service.OrderCoffee("latte");

            Assert.NotNull(coffee);
        }
    }
}
