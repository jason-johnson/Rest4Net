﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Rest4Net.Tests.Integration
{
    public class BasicTests : IClassFixture<WebApplicationFactory<WebApi.Startup>>
    {
        private readonly WebApplicationFactory<WebApi.Startup> _factory;

        public BasicTests(WebApplicationFactory<WebApi.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/Coffee")]
        [InlineData("/blog")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
