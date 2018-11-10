﻿
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Rest4Net.Tests.Integration
{
    public class CoffeeServiceTests : IClassFixture<WebApplicationFactory<WebApi.Startup>>
    {
        private readonly WebApplicationFactory<WebApi.Startup> _factory;

        public CoffeeServiceTests(WebApplicationFactory<WebApi.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task TestGetCoffee()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Coffee");

            //var service = new CoffeeShop(new TestRepository<Coffee>(new List<Coffee> { new Coffee("latte", 3) }));
            //var coffee = service.OrderCoffee("latte");

            Assert.NotNull(response);
        }
    }
}
