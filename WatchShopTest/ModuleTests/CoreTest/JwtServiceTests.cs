using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WatchShop_Core.Domain.Entities.Identities;
using WatchShop_Core.Services;

namespace WatchShopTest.ModuleTests.CoreTest
{
    public class JwtServiceTests
    {
        [Fact]
        public async Task CreateJwtTokenAsync_ValidUser_ReturnsToken()
        {
            // Arrange
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "ApiSettings:Secret", "THIS IS SECRET KEY FOR WORKING IN APPLICATION" }
                })
                .Build();

            var userManagerMock = new Mock<UserManager<ApplicationUser>>(
                Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);

            var applicationUser = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                UserName = "testUser",
                Email = "test@example.com"
            };

            userManagerMock.Setup(um => um.GetRolesAsync(applicationUser))
                .ReturnsAsync(new List<string> { "Client", "Admin" });

            var jwtService = new JwtService(configuration, userManagerMock.Object);

            // Act
            var token = await jwtService.CreateJwtTokenAsync(applicationUser);

            // Assert
            Assert.NotNull(token);
            Assert.True(!string.IsNullOrWhiteSpace(token));

            // Decode the token to ensure it's properly formed
            var tokenHandler = new JwtSecurityTokenHandler();
            var decodedToken = tokenHandler.ReadJwtToken(token);

            Assert.Equal("testUser", decodedToken.Claims.FirstOrDefault(c => c.Type == "username")?.Value);
            Assert.Equal("test@example.com", decodedToken.Claims.FirstOrDefault(c => c.Type == "email")?.Value);
        }
    }
}
