using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Linq.Expressions;
using WatchShop_Core.Domain.Entities.Identities;
using WatchShop_Core.Domain.Enums;
using WatchShop_Core.Domain.RepositoryContracts;
using WatchShop_Core.Models.Users.Request;
using WatchShop_Core.Models.Users.Response;
using WatchShop_Core.Services;

namespace WatchShopTest.ModuleTests.CoreTest
{
    public class UserServiceTests
    {
        [Fact]
        public async Task SetSubscriptionLetters_UserExistsAndIsActiveTrue_UpdatesSubscriptionLettersAndReturnsTrue()
        {
            // Arrange
            var userEmail = "test@example.com";
            var isActive = true;

            var user = new ApplicationUser { Email = userEmail, IsSubscriptionLetters = !isActive };

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetByEmailAsync(userEmail))
                              .ReturnsAsync(user);

            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            var userManagerMock = new Mock<UserManager<ApplicationUser>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);

            userManagerMock.Setup(manager => manager.UpdateAsync(user))
                            .ReturnsAsync(IdentityResult.Success);

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(uow => uow.UserRepository)
                          .Returns(userRepositoryMock.Object);

            var userService = new UserService(userManagerMock.Object, unitOfWorkMock.Object, null);

            // Act
            var result = await userService.SetSubscriptionLetters(userEmail, isActive);

            // Assert
            Assert.True(result);
            Assert.Equal(isActive, user.IsSubscriptionLetters);
            userManagerMock.Verify(manager => manager.UpdateAsync(user), Times.Once);
            unitOfWorkMock.Verify(uow => uow.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteUserAsync_UserExists_DeletesUser()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var user = new ApplicationUser { Id = userId };

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetByIdAsync(userId))
                              .ReturnsAsync(user);

            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            var userManagerMock = new Mock<UserManager<ApplicationUser>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);

            userManagerMock.Setup(manager => manager.DeleteAsync(user))
                            .ReturnsAsync(IdentityResult.Success);

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(uow => uow.UserRepository)
                          .Returns(userRepositoryMock.Object);

            var userService = new UserService(userManagerMock.Object, unitOfWorkMock.Object, null);

            // Act
            await userService.DeleteUserAsync(userId);

            // Assert
            userManagerMock.Verify(manager => manager.DeleteAsync(user), Times.Once);
            unitOfWorkMock.Verify(uow => uow.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task GetUserByIdAsync_UserExists_ReturnsUserModel()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var user = new ApplicationUser { Id = userId, UserName = "testuser" };

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetByIdAsync(userId))
                              .ReturnsAsync(user);

            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            var userManagerMock = new Mock<UserManager<ApplicationUser>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);

            userManagerMock.Setup(manager => manager.GetRolesAsync(user))
                            .ReturnsAsync(new List<string> { "Admin" });

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(uow => uow.UserRepository)
                          .Returns(userRepositoryMock.Object);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<UserModel>(user))
                       .Returns(new UserModel { Id = userId, UserName = "testuser" });

            var userService = new UserService(userManagerMock.Object, unitOfWorkMock.Object, mapperMock.Object);

            // Act
            var result = await userService.GetUserByIdAsync(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userId, result.Id);
            Assert.Equal("testuser", result.UserName);
            Assert.Equal("Admin", result.Role);
        }

        [Fact]
        public async Task GetUserByUserNameAsync_UserExists_ReturnsUserModel()
        {
            // Arrange
            var username = "testuser";
            var user = new ApplicationUser { UserName = username };

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.FindUserByUserNameAsync(username))
                              .ReturnsAsync(user);

            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            var userManagerMock = new Mock<UserManager<ApplicationUser>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);

            userManagerMock.Setup(manager => manager.GetRolesAsync(user))
                            .ReturnsAsync(new List<string> { "Admin" });

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(uow => uow.UserRepository)
                          .Returns(userRepositoryMock.Object);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<UserModel>(user))
                       .Returns(new UserModel { UserName = username });

            var userService = new UserService(userManagerMock.Object, unitOfWorkMock.Object, mapperMock.Object);

            // Act
            var result = await userService.GetUserByUserNameAsync(username);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(username, result.UserName);
            Assert.Equal("Admin", result.Role);
        }

        [Fact]
        public async Task GetAllUsersAsync_UsersExist_ReturnsUserModels()
        {
            // Arrange
            var user1 = new ApplicationUser { Id = Guid.NewGuid(), UserName = "user1" };
            var user2 = new ApplicationUser { Id = Guid.NewGuid(), UserName = "user2" };
            var user3 = new ApplicationUser { Id = Guid.NewGuid(), UserName = "user3" };

            var userList = new List<ApplicationUser> { user1, user2, user3 };

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetAllAsync(It.IsAny<Expression<Func<ApplicationUser, object>>[]>()))
                              .ReturnsAsync(userList);

            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            var userManagerMock = new Mock<UserManager<ApplicationUser>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);

            userManagerMock.SetupSequence(manager => manager.GetRolesAsync(It.IsAny<ApplicationUser>()))
                            .ReturnsAsync(new List<string> { "Admin" })
                            .ReturnsAsync(new List<string> { "User" })
                            .ReturnsAsync(new List<string> { "Guest" });

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(uow => uow.UserRepository)
                          .Returns(userRepositoryMock.Object);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<IEnumerable<UserModel>>(userList))
                       .Returns(userList.Select(u => new UserModel { Id = u.Id, UserName = u.UserName }));

            var userService = new UserService(userManagerMock.Object, unitOfWorkMock.Object, mapperMock.Object);

            // Act
            var result = await userService.GetAllUsersAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userList.Count, result.Count());
        }
    }
}
