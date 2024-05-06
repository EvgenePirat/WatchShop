using Bogus;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using WatchShop;
using WatchShop_UI.Dtos.Auth.Request;

namespace WatchShopTest.IntegrationTests
{
    public class AuthenticateControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly Faker _faker;

        public AuthenticateControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _faker = new Faker();
        }

        [Fact]
        public async Task RegisterAsync_ReturnsOkResponse()
        {
            // Arrange
            var client = _factory.CreateClient();
            var registerDto = new RegisterDto
            {
                Username = "testadmin",
                Password = "password",
                Email = _faker.Internet.Email(),
                Role = "Admin"
            };

            var content = new StringContent(JsonConvert.SerializeObject(registerDto), Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync("/api/Authenticate/register", content);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task LoginAsync_ReturnsOkResponse()
        {
            // Arrange
            var client = _factory.CreateClient();
            var loginDto = new LoginDto
            {
                Username = "testUser",
                Password = "password",
            };

            var content = new StringContent(JsonConvert.SerializeObject(loginDto), Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync("/api/Authenticate/login", content);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
