using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using WatchShop;
using WatchShop_UI.Dtos.Messages.Request;
using WatchShop_UI.Utilities.GeneralResponse;

namespace WatchShopTest.IntegrationTests
{
    public class MessageControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public MessageControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task PostMessageAsync_ReturnsOkResponse()
        {
            // Arrange
            var client = _factory.CreateClient();
            var messageDto = new PostMessageDto
            {
                FirstName= "TestFirstName",
                LastName = "TestLastName",
                Email = "testemail@gmail.com",
                Message = "Message post for test",
                Phone = "0683215467"
            };

            var content = new StringContent(JsonConvert.SerializeObject(messageDto), Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync("/api/Message", content);

            // Assert
            response.EnsureSuccessStatusCode();

            var contentString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<ApiResponse>(contentString);

            Assert.NotNull(responseObject);
            Assert.Equal(HttpStatusCode.OK, responseObject.StatusCode);
        }
    }
}
