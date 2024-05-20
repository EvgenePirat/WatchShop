using Bogus;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;
using Telegram.Bot.Types;
using WatchShop;
using WatchShop_UI.Dtos.Auth.Request;
using WatchShopTest.Utilities;

[assembly: CollectionBehavior(CollectionBehavior.CollectionPerAssembly)]
namespace WatchShopTest.IntegrationTests
{
    [TestCaseOrderer(
        ordererTypeName: "WatchShopTest.Utilities.PriorityOrderer",
        ordererAssemblyName: "WatchShopTest")]
    public class AuthenticateControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly Faker _faker;
        public static Guid UserId { get; private set; }

        public AuthenticateControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _faker = new Faker();
        }

        [Fact, TestPriority(-50)]
        public async Task RegisterAsync_ReturnsOkResponse()
        {
            // Arrange
            var client = _factory.CreateClient();
            var registerDto = new RegisterDto
            {
                Username = "testadminPro",
                Password = "passwordPro",
                Email = "PasswordProTest@gmail.com",
                Role = "Client"
            };

            var content = new StringContent(JsonConvert.SerializeObject(registerDto), Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync("/api/Authenticate/register", content);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var createResponseContent = await response.Content.ReadAsStringAsync();

            var jsonObject = JObject.Parse(createResponseContent);

            string username = jsonObject["result"]["username"].ToString();

            Assert.NotNull(jsonObject);
            Assert.Equal("testadminPro", username);

            Guid userId = Guid.Parse(jsonObject["result"]["id"].ToString());

            UserId = userId;
        }

        [Fact, TestPriority(0)]
        public async Task LoginAsync_ReturnsOkResponse()
        {
            // Arrange
            var client = _factory.CreateClient();
            var loginDto = new LoginDto
            {
                Username = "testadminPro",
                Password = "passwordPro",
            };

            var content = new StringContent(JsonConvert.SerializeObject(loginDto), Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync("/api/Authenticate/login", content);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact, TestPriority(20)]
        public async Task DeleteUserAsync_DeletesUser()
        {
            // Arrange
            var client = _factory.CreateClient();
            var userId = UserId;

            var token = await GetAccessTokenAsync(client);

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            // Act
            var response = await client.DeleteAsync($"/api/user/{userId}");

            // Assert
            response.EnsureSuccessStatusCode(); 
            Assert.Equal(HttpStatusCode.OK, response.StatusCode); 
        }

        private async Task<string> GetAccessTokenAsync(HttpClient client)
        {
            var loginDto = new LoginDto
            {
                Username = "testadmin",
                Password = "password",
            };

            var content = new StringContent(JsonConvert.SerializeObject(loginDto), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/Authenticate/login", content);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            var jsonObject = JObject.Parse(responseContent);

            string token = jsonObject["result"]["token"].ToString();

            return token;
        }
    }
}
