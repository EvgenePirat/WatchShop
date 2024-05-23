using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using WatchShop;
using WatchShopTest.Utilities;
using WatchShop_UI.Dtos.Auth.Request;
using System.ComponentModel;
using Bogus;
using Microsoft.AspNetCore.Http;
using WatchShop_UI.Dtos.ClockFaces.Request;
using WatchShop_UI.Dtos.Frames.Request;
using WatchShop_UI.Dtos.Straps.Request;
using WatchShop_UI.Dtos.Watches.Request;
using WatchShop_UI.Dtos.Watches.Response;
using WatchShop_UI.Utilities.GeneralResponse;
using WatchShop_UI.Dtos.Brends.Response;
using System.Net.Http.Headers;
using WatchShop_UI.Dtos.Users.Response;
using System.ComponentModel.Design;
using WatchShop_UI.Dtos.Comments.Request;
using WatchShop_UI.Dtos.Orders.Request;
using WatchShop_UI.Dtos.Carts.Request;
using WatchShop_UI.Dtos.Payments.Request;
using WatchShop_UI.Dtos.Shipments.Request;
using WatchShop_UI.Dtos.Orders.Response;

namespace WatchShopTest.IntegrationTests
{
    [TestCaseOrderer(
            ordererTypeName: "WatchShopTest.Utilities.PriorityOrderer",
            ordererAssemblyName: "WatchShopTest")]
    public class IntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {

        private readonly WebApplicationFactory<Program> _factory;
        public static int BrendId { get; private set; }
        public static int WatchId { get; private set; }
        public static Guid UserId { get; private set; }
        public static Guid ComentId { get; private set; }
        public static Guid OrderId { get; private set; }

        public IntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact, TestPriority(-50)]
        public async Task Create_BrendAsync_ReturnOk()
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

            BrendId = int.Parse(jsonObject["result"]["id"].ToString());
        }

        [Fact, TestPriority(-45)]
        public async Task GetBrendByIdAsync_ReturnsBrend()
        {
            // Arrange
            var client = _factory.CreateClient();

            var token = await GetAccessTokenAsync(client);

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            int brendId = BrendId;

            // Act
            var response = await client.GetAsync($"/api/Brend/{brendId}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var createResponseContent = await response.Content.ReadAsStringAsync();

            var jsonObject = JObject.Parse(createResponseContent);

            Assert.NotNull(jsonObject);
            Assert.Equal(brendId, int.Parse(jsonObject["result"]["id"].ToString()));
        }

        [Fact, TestPriority(-35)]
        public async Task UpdateBrendAsync_ReturnsOk()
        {
            // Arrange
            var client = _factory.CreateClient();

            var token = await GetAccessTokenAsync(client);

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            int brendId = BrendId; 

            var updateBrendDto = new
            {
                Name = "UpdatedBrendName",
            };

            var json = JsonConvert.SerializeObject(updateBrendDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var response = await client.PutAsync($"/api/Brend/{brendId}", content);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var createResponseContent = await response.Content.ReadAsStringAsync();

            var jsonObject = JObject.Parse(createResponseContent);

            Assert.NotNull(jsonObject);
            Assert.Equal(brendId, int.Parse(jsonObject["result"]["id"].ToString()));
            Assert.Equal("UpdatedBrendName", jsonObject["result"]["name"].ToString());
        }


        [Fact, TestPriority(0)]
        public async Task Create_WatchAsync_ReturnOk()
        {
            // Arrange
            var client = _factory.CreateClient();

            var adminToken = await GetAccessTokenAsync(client);

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {adminToken}");

            var createWatchDto = new CreateWatchDto
            {
                NameModel = "Test Watch",
                Gender = "Men",
                Guarantee = "Twelve",
                Price = 299.99,
                Description = "A test watch description",
                TimeFormat = "TwentyFourHour",
                IsDiscounted = false,
                State = "New",
                DiscountPrice = null,
                BrendId = BrendId,
                StyleId = 2,
                Strap = new CreateStrapDto { Name="Strap", StrapMaterialId = 2 },
                CountryId = 6,
                MechanismTypeId = 1,
                GlassTypeId = 2,
                ClockFace = new CreateClockFaceDto { ClockFaceColorId = 7, IndicationKindId = 2, IndicationTypeId = 1 },
                Frame = new CreateFrameDto { CaseShape = "Oval", FrameColorId = 4, FrameMaterialId = 2, WaterResistance = "FiveHundredWR", Dimensions = new WatchShop_UI.Dtos.Dimensions.Request.CreateDimensionDto() { CaseDiameter = "From21To33mm", Length = 10, Thickness = 23, Weight = 13, Width = 34 } },
                Files = new List<IFormFile>
                {
                    new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("fake file content")), 0, 10, "Data", "testfile.txt")
                    {
                        Headers = new HeaderDictionary(),
                        ContentType = "text/plain"
                    }
                },
                WatchAdditionalCharacteristicsList = new List<int> { 1, 2, 3 }
            };

            var content = new MultipartFormDataContent();

            // Пример добавления сложных объектов
            content.Add(new StringContent(createWatchDto.NameModel), "NameModel");
            content.Add(new StringContent(createWatchDto.Gender), "Gender");
            content.Add(new StringContent(createWatchDto.Guarantee), "Guarantee");
            content.Add(new StringContent(createWatchDto.Price.ToString()), "Price");
            content.Add(new StringContent(createWatchDto.Description), "Description");
            content.Add(new StringContent(createWatchDto.TimeFormat), "TimeFormat");
            content.Add(new StringContent(createWatchDto.IsDiscounted.ToString()), "IsDiscounted");
            content.Add(new StringContent(createWatchDto.State), "State");
            content.Add(new StringContent(createWatchDto.DiscountPrice.ToString()), "DiscountPrice");
            content.Add(new StringContent(createWatchDto.BrendId.ToString()), "BrendId");
            content.Add(new StringContent(createWatchDto.StyleId.ToString()), "StyleId");
            content.Add(new StringContent(createWatchDto.CountryId.ToString()), "CountryId");
            content.Add(new StringContent(createWatchDto.MechanismTypeId.ToString()), "MechanismTypeId");
            content.Add(new StringContent(createWatchDto.GlassTypeId.ToString()), "GlassTypeId");

            // Добавление сложных объектов
            AddComplexObjectToContent(content, createWatchDto.Strap, "Strap");
            AddComplexObjectToContent(content, createWatchDto.ClockFace, "ClockFace");
            AddComplexObjectToContent(content, createWatchDto.Frame, "Frame");

            // Добавление сложных объектов
            AddComplexObjectToContent(content, createWatchDto.Strap, "Strap");
            AddComplexObjectToContent(content, createWatchDto.ClockFace, "ClockFace");
            AddComplexObjectToContent(content, createWatchDto.Frame, "Frame");

            // Добавление файлов
            foreach (var file in createWatchDto.Files)
            {
                var fileContent = new StreamContent(file.OpenReadStream());
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
                content.Add(fileContent, "Files", file.FileName);
            }

            // Добавление WatchAdditionalCharacteristicsList
            foreach (var item in createWatchDto.WatchAdditionalCharacteristicsList)
            {
                content.Add(new StringContent(item.ToString()), "WatchAdditionalCharacteristicsList");
            }

            // Act
            var response = await client.PostAsync("/api/watch", content);


            // Assert
            var responseContent = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseContent);

            response.EnsureSuccessStatusCode(); // Гарантируем успешный ответ
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode); // Проверяем, что возвращается статус код 200

            Assert.NotNull(apiResponse); // Проверяем, что ответ не является пустым
            Assert.Equal(System.Net.HttpStatusCode.OK, apiResponse.StatusCode); // Проверяем, что статус код в ApiResponse равен 200

            var createResponseContent = await response.Content.ReadAsStringAsync();

            var jsonObject = JObject.Parse(createResponseContent);

            WatchId = int.Parse(jsonObject["result"]["id"].ToString());
        }

        [Fact, TestPriority(5)]
        public async Task GetWatchByNameModelAsync_ReturnsWatch()
        {
            // Arrange
            var client = _factory.CreateClient();

            var token = await GetAccessTokenAsync(client);

            // Додавання токена доступу до заголовків запиту
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            string nameModel = "Test Watch"; // Замість цього значення встановіть реальну модель для тестування

            // Act
            var response = await client.GetAsync($"/api/Watch/{nameModel}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var createResponseContent = await response.Content.ReadAsStringAsync();

            var jsonObject = JObject.Parse(createResponseContent);

            string nameModelResponse = jsonObject["result"]["nameModel"].ToString();

            Assert.NotNull(jsonObject);
            Assert.Equal(nameModel, nameModelResponse);
        }

        [Fact, TestPriority(10)]
        public async Task GetUserByUserNameAsync_ReturnsUser()
        {
            // Arrange
            var client = _factory.CreateClient();

            var token = await GetAccessTokenAsync(client);

            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/user/testadmin");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Act
            var response = await client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var createResponseContent = await response.Content.ReadAsStringAsync();

            var jsonObject = JObject.Parse(createResponseContent);

            string username = jsonObject["result"]["userName"].ToString();

            Assert.NotNull(jsonObject);
            Assert.Equal("testadmin", username);

            Guid userId = Guid.Parse(jsonObject["result"]["id"].ToString());

            UserId = userId; 
        }

        [Fact, TestPriority(25)]
        public async Task CreateCommentAsync_ReturnsCreatedResponse()
        {
            // Arrange
            var client = _factory.CreateClient();

            var adminToken = await GetAccessTokenAsync(client);

            var request = new HttpRequestMessage(HttpMethod.Post, "/api/comment");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", adminToken);

            var createCommentDto = new CreateCommentDto()
            {
                Comment = "This is a test comment",
                Grade = 4,
                UserId = UserId,
                WatchId = WatchId
            };

            var content = new StringContent(JsonConvert.SerializeObject(createCommentDto), Encoding.UTF8, "application/json");

            request.Content = content;

            // Act
            var response = await client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var responseContent = await response.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(responseContent);

            ComentId = Guid.Parse(jsonObject["result"]["id"].ToString());

            Assert.Equal("This is a test comment", jsonObject["result"]["comment"].ToString());
        }

        [Fact, TestPriority(35)]
        public async Task GetCommentByIdAsync_ReturnsOkResponse()
        {
            // Arrange
            var client = _factory.CreateClient();

            var adminToken = await GetAccessTokenAsync(client);

            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/comment/{ComentId}");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", adminToken);

            // Act
            var response = await client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var responseContent = await response.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(responseContent);

            Assert.Equal(ComentId.ToString(), jsonObject["result"]["id"].ToString());
            Assert.Equal("This is a test comment", jsonObject["result"]["comment"].ToString());
        }

        [Fact, TestPriority(50)]
        public async Task UpdateCommentAsync_ReturnsOkResponse()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Assume you have a method to get a valid token
            var token = await GetAccessTokenAsync(client);

            // Use a previously created comment ID for updating
            var commentId = ComentId;

            var updateCommentDto = new UpdateCommentDto()
            {
                Comment = "This is an updated test comment",
                UserId = UserId,
                WatchId = WatchId,
                Grade = 3
            };

            var request = new HttpRequestMessage(HttpMethod.Put, $"/api/comment/{commentId}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var content = new StringContent(JsonConvert.SerializeObject(updateCommentDto), Encoding.UTF8, "application/json");
            request.Content = content;

            // Act
            var response = await client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var responseContent = await response.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(responseContent);

            Assert.Equal(commentId.ToString(), jsonObject["result"]["id"].ToString());
            Assert.Equal("This is an updated test comment", jsonObject["result"]["comment"].ToString());
        }

        [Fact, TestPriority(75)]
        public async Task CreateOrderAsync_ReturnsCreatedResponse()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Получение токена доступа
            var token = await GetAccessTokenAsync(client);

            var createOrderDto = new CreateOrderDto
            {
                Sum = 300.00,
                UserId = UserId,
                Shipment = new CreateShipmentDto
                {
                    Address = "123 Street, City, Country",
                    ApplicationUserId = UserId,
                    City = "Odessa",
                    Country = "Ukraine"
                },
                Payment = new CreatePaymentDto
                {
                    PaymentMethod = "Cash",
                    ApplicationUserId = UserId,
                    Amount = 300.00,
                    StripeIntendId = ""
                },
                Carts = new List<CreateCartDto>
                {
                    new CreateCartDto
                    {
                        WatchId = WatchId,
                        Count = 1,
                    }
                },
                Comment = "Please deliver between 9 AM and 5 PM."
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "/api/order");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var content = new StringContent(JsonConvert.SerializeObject(createOrderDto), Encoding.UTF8, "application/json");
            request.Content = content;

            // Act
            var response = await client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var responseContent = await response.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(responseContent);

            Assert.NotNull(jsonObject["result"]);
            Assert.Equal(createOrderDto.Sum, (double)jsonObject["result"]["sum"]);
            Assert.Equal(createOrderDto.UserId.ToString(), (string)jsonObject["result"]["userId"]);
            Assert.Equal(createOrderDto.Shipment.Address, (string)jsonObject["result"]["shipment"]["address"]);
            Assert.Equal(createOrderDto.Payment.PaymentMethod, (string)jsonObject["result"]["payment"]["paymentMethod"]);
            Assert.Equal(createOrderDto.Carts.First().WatchId, (int)jsonObject["result"]["carts"].First()["watchId"]);
            Assert.Equal(createOrderDto.Comment, (string)jsonObject["result"]["comment"]);

            OrderId = Guid.Parse(jsonObject["result"]["id"].ToString());
        }

        [Fact, TestPriority(90)]
        public async Task GetOrderByIdAsync_ReturnsOrderWithCorrectId()
        {
            // Arrange
            var client = _factory.CreateClient();
            var orderId = OrderId;

            var adminToken = await GetAccessTokenAsync(client);

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {adminToken}");

            // Act
            var response = await client.GetAsync($"/api/order/{orderId}");

            // Assert
            response.EnsureSuccessStatusCode(); 
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var responseContent = await response.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(responseContent);

            Assert.Equal(orderId, Guid.Parse(jsonObject["result"]["id"].ToString()));
        }

        [Fact, TestPriority(105)]
        public async Task UpdateOrderStatusAsync_ChangesOrderStatusToSent()
        {
            // Arrange
            var client = _factory.CreateClient();
            var orderId = OrderId;
            var newStatus = "Sent";

            var adminToken = await GetAccessTokenAsync(client);

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {adminToken}");

            // Act
            var response = await client.PutAsync($"/api/order/status/{orderId}&{newStatus}", new StringContent(""));

            // Assert
            response.EnsureSuccessStatusCode(); // Проверка успешности ответа
            Assert.Equal(HttpStatusCode.OK, response.StatusCode); // Проверка статуса кода

            var responseContent = await response.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(responseContent);

            Assert.Equal(newStatus, jsonObject["result"]["orderStatus"]["name"].ToString());
        }

        [Fact, TestPriority(170)]
        public async Task DeleteCommentAsync_ReturnsOkResponse()
        {
            // Arrange
            var client = _factory.CreateClient();

            var adminToken = await GetAccessTokenAsync(client);

            var request = new HttpRequestMessage(HttpMethod.Delete, $"/api/comment/{ComentId}");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", adminToken);

            // Act
            var response = await client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.Contains($"Comment {ComentId} - was deleted", responseContent);
        }

        [Fact, TestPriority(190)]
        public async Task DeleteOrderAsync_DeletesOrder()
        {
            // Arrange
            var client = _factory.CreateClient();
            var orderId = OrderId;

            var adminToken = await GetAccessTokenAsync(client);

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {adminToken}");

            // Act
            var response = await client.DeleteAsync($"/api/order/{orderId}");

            // Assert
            response.EnsureSuccessStatusCode(); 
            Assert.Equal(HttpStatusCode.OK, response.StatusCode); 
        }

        [Fact, TestPriority(200)]
        public async Task Delete_WatchAsync_ReturnOk()
        {
            var client = _factory.CreateClient();

            var adminToken = await GetAccessTokenAsync(client);

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {adminToken}");

            var deleteResponse = await client.DeleteAsync($"/api/watch/{WatchId}");

            // Assert: Проверка успешного ответа при удалении
            deleteResponse.EnsureSuccessStatusCode(); // Гарантируем успешный ответ
            Assert.Equal(System.Net.HttpStatusCode.OK, deleteResponse.StatusCode); // Проверяем, что возвращается статус код 200

            var deleteResponseContent = await deleteResponse.Content.ReadAsStringAsync();
            var deleteApiResponse = JsonConvert.DeserializeObject<ApiResponse>(deleteResponseContent);

            Assert.NotNull(deleteApiResponse); // Проверяем, что ответ не является пустым
            Assert.Equal(System.Net.HttpStatusCode.OK, deleteApiResponse.StatusCode); // Проверяем, что статус код в ApiResponse равен 200
        }

        [Fact, TestPriority(250)]
        public async Task Delete_BrendAsync_ReturnOk()
        {
            var client = _factory.CreateClient();

            var adminToken = await GetAccessTokenAsync(client);

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {adminToken}");

            var deleteRequest = new HttpRequestMessage(HttpMethod.Delete, $"/api/brend/{BrendId}");

            // Act
            var deleteResponse = await client.SendAsync(deleteRequest);

            // Assert
            deleteResponse.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);
        }

        private void AddComplexObjectToContent(MultipartFormDataContent content, object obj, string prefix)
        {
            if (obj == null) return;

            foreach (var property in obj.GetType().GetProperties())
            {
                var value = property.GetValue(obj);
                if (value != null)
                {
                    if (value.GetType().IsClass && value.GetType() != typeof(string))
                    {
                        AddComplexObjectToContent(content, value, $"{prefix}.{property.Name}");
                    }
                    else
                    {
                        content.Add(new StringContent(value.ToString()), $"{prefix}.{property.Name}");
                    }
                }
            }
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
