using Xunit;
using MyProject.IntegrationTests.Fixtures;
using RestSharp;
using System.Net;

namespace MyProject.IntegrationTests
{
    [Trait("Category", "Integration")]
    public class HomeControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly RestClient _client;

        public HomeControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            var httpClient = factory.CreateClient();
            _client = new RestClient(httpClient);
        }

        [Fact]
        public async Task Index_ReturnsOkResponse()
        {
            // Arrange
            var request = new RestRequest("/");
            
            // Act
            var response = await _client.ExecuteAsync(request);
            
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Privacy_ReturnsOkResponse()
        {
            // Arrange
            var request = new RestRequest("/Home/Privacy");
            
            // Act
            var response = await _client.ExecuteAsync(request);
            
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Index_ReturnsHtmlContent()
        {
            // Arrange
            var request = new RestRequest("/");
            
            // Act
            var response = await _client.ExecuteAsync(request);
            
            // Assert
            Assert.Contains("text/html", response.ContentType ?? "");
        }
    }
}