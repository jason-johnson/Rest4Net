using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Rest4Net.Tests.Integration
{
    public class BasicTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public BasicTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            if(!response.IsSuccessStatusCode)
            {
                var error = response.Content.ReadAsStringAsync();
                throw new Exception($"error with url '{url}': '{response.ReasonPhrase} - {(string.IsNullOrEmpty(error.Result) ? "none" : error.Result)}'");
            }

            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
