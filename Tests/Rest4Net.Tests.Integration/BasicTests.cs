using System;
using System.Threading.Tasks;
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
