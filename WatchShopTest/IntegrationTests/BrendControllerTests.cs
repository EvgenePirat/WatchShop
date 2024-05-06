using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;
using WatchShop;
using WatchShop_UI.Dtos.Auth.Request;
using WatchShop_UI.Dtos.Auth.Response;
using WatchShopTest.Utilities;

namespace WatchShopTest.IntegrationTests
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class BrendControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public BrendControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        [Priority(1)]
        public async Task Create_Delete_BrendAsync_ReturnsCreatedResponse()
        {
            // Arrange
            var client = _factory.CreateClient();

            var token = await GetAccessTokenAsync(client);

            var request = new HttpRequestMessage(HttpMethod.Post, "/api/brend");

            request.Headers.Add("Authorization", $"Bearer {token}");

            var formData = new Dictionary<string, string>
            {
                { "Name", "BrendTest" } 
            };

            var json = JsonConvert.SerializeObject(formData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            request.Content = content;

            // Act
            var response = await client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

            var createResponseContent = await response.Content.ReadAsStringAsync();

            var jsonObject = JObject.Parse(createResponseContent);

            string id = jsonObject["result"]["id"].ToString();

            var deleteRequest = new HttpRequestMessage(HttpMethod.Delete, $"/api/brend/{id}");
            deleteRequest.Headers.Add("Authorization", $"Bearer {token}");

            // Act
            var deleteResponse = await client.SendAsync(deleteRequest);

            // Assert
            deleteResponse.EnsureSuccessStatusCode(); 
            Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);
        }

        [Fact]
        [Priority(3)]
        public async Task Create_GetById_Delete_BrendAsync_ReturnsCreatedResponse()
        {
            var client = _factory.CreateClient();

            var token = await GetAccessTokenAsync(client);

            var request = new HttpRequestMessage(HttpMethod.Post, "/api/brend");

            request.Headers.Add("Authorization", $"Bearer {token}");

            var formData = new Dictionary<string, string>
            {
                { "Name", "BrendTest" }
            };

            var json = JsonConvert.SerializeObject(formData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            request.Content = content;

            // Act
            var response = await client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

            var createResponseContent = await response.Content.ReadAsStringAsync();

            var jsonObject = JObject.Parse(createResponseContent);

            string id = jsonObject["result"]["id"].ToString();

            var getRequest = new HttpRequestMessage(HttpMethod.Get, $"/api/brend/{id}");
            getRequest.Headers.Add("Authorization", $"Bearer {token}");

            // Act
            var getResponse = await client.SendAsync(getRequest);

            // Assert
            getResponse.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

            var deleteRequest = new HttpRequestMessage(HttpMethod.Delete, $"/api/brend/{id}");
            deleteRequest.Headers.Add("Authorization", $"Bearer {token}");

            // Act
            var deleteResponse = await client.SendAsync(deleteRequest);

            // Assert
            deleteResponse.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);
        }

        [Fact]
        [Priority(5)]
        public async Task Create_GetByName_Delete_BrendAsync_ReturnsCreatedResponse()
        {
            var client = _factory.CreateClient();

            var token = await GetAccessTokenAsync(client);

            var request = new HttpRequestMessage(HttpMethod.Post, "/api/brend");

            request.Headers.Add("Authorization", $"Bearer {token}");

            var formData = new Dictionary<string, string>
            {
                { "Name", "BrendTest" }
            };

            var json = JsonConvert.SerializeObject(formData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            request.Content = content;

            // Act
            var response = await client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

            var createResponseContent = await response.Content.ReadAsStringAsync();

            var jsonObject = JObject.Parse(createResponseContent);

            string name = jsonObject["result"]["name"].ToString();
            string id = jsonObject["result"]["id"].ToString();

            var getRequest = new HttpRequestMessage(HttpMethod.Get, $"/api/brend/{name}");
            getRequest.Headers.Add("Authorization", $"Bearer {token}");

            // Act
            var getResponse = await client.SendAsync(getRequest);

            // Assert
            getResponse.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

            var deleteRequest = new HttpRequestMessage(HttpMethod.Delete, $"/api/brend/{id}");
            deleteRequest.Headers.Add("Authorization", $"Bearer {token}");

            // Act
            var deleteResponse = await client.SendAsync(deleteRequest);

            // Assert
            deleteResponse.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);
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
