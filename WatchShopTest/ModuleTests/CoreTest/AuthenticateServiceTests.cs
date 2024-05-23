using Microsoft.AspNetCore.Identity;
using Moq;
using WatchShop_Core.Domain.Entities.Identities;
using WatchShop_Core.Domain.RepositoryContracts;
using WatchShop_Core.Models.Auth.Request;
using WatchShop_Core.Models.Enums;
using WatchShop_Core.ServiceContracts;
using WatchShop_Core.Services;

namespace WatchShopTest.ModuleTests.CoreTest
{
    public class AuthenticateServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;
        private readonly Mock<RoleManager<IdentityRole>> _roleManagerMock;
        private readonly Mock<IJwtService> _jwtServiceMock;
        private readonly AuthenticateService _authService;

        public AuthenticateServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);
            _jwtServiceMock = new Mock<IJwtService>();
            var roleStoreMock = new Mock<IRoleStore<IdentityRole>>();
            _roleManagerMock = new Mock<RoleManager<IdentityRole>>(roleStoreMock.Object, null, null, null, null);

            _authService = new AuthenticateService(_jwtServiceMock.Object, _unitOfWorkMock.Object, _userManagerMock.Object, null);
        }

        [Fact]
        public async Task LoginAsync_ValidCredentials_ReturnsAuthResponseModel()
        {
            // Arrange
            var users = new List<ApplicationUser>
            {
                new ApplicationUser { UserName = "testuser", Email = "test@example.com" }
            };

            _unitOfWorkMock.Setup(uow => uow.UserRepository.GetAllAsync()).ReturnsAsync(users);

            var loginModel = new LoginModel
            {
                Username = "testuser",
                Password = "testpassword"
            };

            _userManagerMock.Setup(um => um.CheckPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(true);

            _jwtServiceMock.Setup(jwt => jwt.CreateJwtTokenAsync(It.IsAny<ApplicationUser>())).ReturnsAsync("testtoken");

            // Act
            var result = await _authService.LoginAsync(loginModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("testuser", result.Username);
            Assert.Equal("testtoken", result.Token);
        }
    }
}
