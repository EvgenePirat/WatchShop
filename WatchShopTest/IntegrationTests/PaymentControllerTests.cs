using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using WatchShop;
using WatchShop_UI.Dtos.Auth.Request;
using WatchShop_UI.Utilities.GeneralResponse;


namespace WatchShopTest.IntegrationTests
{
    public class PaymentControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public PaymentControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task MakePayment_ReturnsCreatedResponse()
        {
            // Arrange
            var client = _factory.CreateClient();
            var cartTotal = 100.0;
            var content = new StringContent("", Encoding.UTF8, "application/json");

            var token = await GetAccessTokenAsync(client);

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            // Act
            var response = await client.PostAsync($"/api/Payment/{cartTotal}", content);

            // Assert
            response.EnsureSuccessStatusCode(); 

            var contentString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<ApiResponse>(contentString);

            Assert.NotNull(responseObject);
            Assert.Equal(HttpStatusCode.Created, responseObject.StatusCode);
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
