using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WatchShop;
using WatchShop_UI.Dtos.Auth.Request;
using WatchShop_UI.Utilities.GeneralResponse;

namespace WatchShopTest.IntegrationTests
{
    public class AnalyticControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public AnalyticControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetSalesStatisticsAsync_ReturnsOkResponse()
        {
            // Arrange
            var client = _factory.CreateClient();

            var token = await GetAccessTokenAsync(client);

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            // Act
            var response = await client.GetAsync("/api/Analytic");

            // Assert
            response.EnsureSuccessStatusCode(); 

            var contentString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<ApiResponse>(contentString);

            Assert.NotNull(responseObject);
            Assert.Equal(HttpStatusCode.OK, responseObject.StatusCode);
            Assert.NotNull(responseObject.Result);
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
