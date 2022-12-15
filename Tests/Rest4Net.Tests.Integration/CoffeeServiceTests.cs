﻿using Microsoft.AspNetCore.Mvc.Testing;

namespace Rest4Net.Tests.Integration
{
    public class CoffeeServiceTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public CoffeeServiceTests(WebApplicationFactory<Program> factory)
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

            if (!response.IsSuccessStatusCode)
            {
                var error = response.Content.ReadAsStringAsync();
                throw new Exception($"error getting /Coffee: '{response.ReasonPhrase} - {(string.IsNullOrEmpty(error.Result) ? "none" : error.Result)}'");
            }

            //var service = new CoffeeShop(new TestRepository<Coffee>(new List<Coffee> { new Coffee("latte", 3) }));
            //var coffee = service.OrderCoffee("latte");

            Assert.NotNull(response);
        }
    }
}
