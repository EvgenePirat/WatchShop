using AutoMapper;
using Moq;
using System.Linq.Expressions;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Domain.RepositoryContracts;
using WatchShop_Core.Exceptions;
using WatchShop_Core.Models.Brends.Request;
using WatchShop_Core.Models.Brends.Response;
using WatchShop_Core.Services;

namespace WatchShopTest.ModuleTests.CoreTest
{
    public class BrendServiceTests
    {

        [Fact]
        public async Task CreateBrendAsync_WhenBrendExists_ThrowsBrendArgumentException()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var brendRepositoryMock = new Mock<IBrendRepository>();
            var mapperMock = new Mock<IMapper>();

            var brendName = "Rollex";
            var model = new CreateBrendModel { Name = brendName };
            var existingBrend = new Brend() { Name = "Rollex" };

            brendRepositoryMock.Setup(repo => repo.FindByBrendNameAsync(brendName))
                .ReturnsAsync(existingBrend);
            unitOfWorkMock.SetupGet(uow => uow.IBrendRepository).Returns(brendRepositoryMock.Object);

            var service = new BrendService(unitOfWorkMock.Object, mapperMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<BrendArgumentException>(() => service.CreateBrendAsync(model));
        }

        [Fact]
        public async Task CreateBrendAsync_WhenBrendDoesNotExist_ReturnsBrendModel()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var brendRepositoryMock = new Mock<IBrendRepository>();
            var mapperMock = new Mock<IMapper>();

            var brendName = "Rollex";
            var model = new CreateBrendModel { Name = brendName };
            var mappedEntity = new Brend();
            var expectedBrendModel = new BrendModel();

            brendRepositoryMock.Setup(repo => repo.FindByBrendNameAsync(brendName))
                .ReturnsAsync((Brend)null);
            brendRepositoryMock.Setup(repo => repo.Add(It.IsAny<Brend>()));
            unitOfWorkMock.SetupGet(uow => uow.IBrendRepository).Returns(brendRepositoryMock.Object);
            mapperMock.Setup(mapper => mapper.Map<Brend>(model)).Returns(mappedEntity);
            mapperMock.Setup(mapper => mapper.Map<BrendModel>(mappedEntity)).Returns(expectedBrendModel);

            var service = new BrendService(unitOfWorkMock.Object, mapperMock.Object);

            // Act
            var result = await service.CreateBrendAsync(model);

            // Assert
            Assert.Equal(expectedBrendModel, result);
            brendRepositoryMock.Verify(repo => repo.FindByBrendNameAsync(brendName), Times.Once);
            brendRepositoryMock.Verify(repo => repo.Add(mappedEntity), Times.Once);
            unitOfWorkMock.Verify(uow => uow.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteBrendAsync_WhenBrendExists_DeletesBrendAndSavesChanges()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var brendRepositoryMock = new Mock<IBrendRepository>();

            var brendId = 1;
            var brendToDelete = new Brend { Id = brendId };

            brendRepositoryMock.Setup(repo => repo.GetByIdAsync(brendId))
                .ReturnsAsync(brendToDelete);
            unitOfWorkMock.SetupGet(uow => uow.IBrendRepository).Returns(brendRepositoryMock.Object);

            var service = new BrendService(unitOfWorkMock.Object, null);

            // Act
            await service.DeleteBrendAsync(brendId);

            // Assert
            brendRepositoryMock.Verify(repo => repo.Delete(brendToDelete), Times.Once);
            unitOfWorkMock.Verify(uow => uow.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteBrendAsync_WhenBrendDoesNotExist_ThrowsBrendArgumentException()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var brendRepositoryMock = new Mock<IBrendRepository>();

            var brendId = 1;

            brendRepositoryMock.Setup(repo => repo.GetByIdAsync(brendId))
                .ReturnsAsync((Brend)null);
            unitOfWorkMock.SetupGet(uow => uow.IBrendRepository).Returns(brendRepositoryMock.Object);

            var service = new BrendService(unitOfWorkMock.Object, null);

            // Act & Assert
            await Assert.ThrowsAsync<BrendArgumentException>(() => service.DeleteBrendAsync(brendId));
            brendRepositoryMock.Verify(repo => repo.Delete(It.IsAny<Brend>()), Times.Never);
            unitOfWorkMock.Verify(uow => uow.SaveAsync(), Times.Never);
        }

        [Fact]
        public async Task GetAllBrendsAsync_ReturnsAllBrends()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var brendRepositoryMock = new Mock<IBrendRepository>();
            var mapperMock = new Mock<IMapper>();

            var brendsFromRepository = new List<Brend>
            {
                new Brend { Id = 1, Name = "Brend 1", Watches = new List<Watch>() },
                new Brend { Id = 2, Name = "Brend 2", Watches = new List<Watch>() }
            };

            brendRepositoryMock.Setup(repo => repo.GetAllAsync(It.IsAny<Expression<Func<Brend, object>>>()))
                .ReturnsAsync(brendsFromRepository);
            unitOfWorkMock.SetupGet(uow => uow.IBrendRepository).Returns(brendRepositoryMock.Object);
            mapperMock.Setup(mapper => mapper.Map<IEnumerable<BrendAllModel>>(brendsFromRepository))
                .Returns(brendsFromRepository.Select(b => new BrendAllModel { Id = b.Id, Name = b.Name }));

            var service = new BrendService(unitOfWorkMock.Object, mapperMock.Object);

            // Act
            var result = await service.GetAllBrendsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(brendsFromRepository.Count, result.Count());
            foreach (var expectedBrend in brendsFromRepository)
            {
                Assert.Contains(result, actualBrend =>
                    actualBrend.Id == expectedBrend.Id && actualBrend.Name == expectedBrend.Name);
            }
        }

        [Fact]
        public async Task GetBrendByIdAsync_WhenBrendExists_ReturnsBrendModel()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var brendRepositoryMock = new Mock<IBrendRepository>();
            var mapperMock = new Mock<IMapper>();

            var brendId = 1;
            var brend = new Brend { Id = brendId, Name = "Test Brend" };

            brendRepositoryMock.Setup(repo => repo.GetByIdAsync(brendId))
                .ReturnsAsync(brend);
            unitOfWorkMock.SetupGet(uow => uow.IBrendRepository).Returns(brendRepositoryMock.Object);
            mapperMock.Setup(mapper => mapper.Map<BrendModel>(brend))
                .Returns(new BrendModel { Id = brend.Id, Name = brend.Name });

            var service = new BrendService(unitOfWorkMock.Object, mapperMock.Object);

            // Act
            var result = await service.GetBrendByIdAsync(brendId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(brend.Id, result.Id);
            Assert.Equal(brend.Name, result.Name);
        }

        [Fact]
        public async Task GetBrendByIdAsync_WhenBrendDoesNotExist_ThrowsBrendArgumentException()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var brendRepositoryMock = new Mock<IBrendRepository>();

            var brendId = 1;

            brendRepositoryMock.Setup(repo => repo.GetByIdAsync(brendId))
                .ReturnsAsync((Brend)null);
            unitOfWorkMock.SetupGet(uow => uow.IBrendRepository).Returns(brendRepositoryMock.Object);

            var service = new BrendService(unitOfWorkMock.Object, Mock.Of<IMapper>());

            // Act & Assert
            await Assert.ThrowsAsync<BrendArgumentException>(() => service.GetBrendByIdAsync(brendId));
        }

        [Fact]
        public async Task GetBrendByNameAsync_WhenBrendExists_ReturnsBrendModel()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var brendRepositoryMock = new Mock<IBrendRepository>();
            var mapperMock = new Mock<IMapper>();

            var brendName = "Test Brend";
            var brend = new Brend { Id = 1, Name = brendName };

            brendRepositoryMock.Setup(repo => repo.FindByBrendNameAsync(brendName))
                .ReturnsAsync(brend);
            unitOfWorkMock.SetupGet(uow => uow.IBrendRepository).Returns(brendRepositoryMock.Object);
            mapperMock.Setup(mapper => mapper.Map<BrendModel>(brend))
                .Returns(new BrendModel { Id = brend.Id, Name = brend.Name });

            var service = new BrendService(unitOfWorkMock.Object, mapperMock.Object);

            // Act
            var result = await service.GetBrendByNameAsync(brendName);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(brend.Id, result.Id);
            Assert.Equal(brend.Name, result.Name);
        }

        [Fact]
        public async Task GetBrendByNameAsync_WhenBrendDoesNotExist_ThrowsBrendArgumentException()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var brendRepositoryMock = new Mock<IBrendRepository>();

            var brendName = "Nonexistent Brend";

            brendRepositoryMock.Setup(repo => repo.FindByBrendNameAsync(brendName))
                .ReturnsAsync((Brend)null);
            unitOfWorkMock.SetupGet(uow => uow.IBrendRepository).Returns(brendRepositoryMock.Object);

            var service = new BrendService(unitOfWorkMock.Object, Mock.Of<IMapper>());

            // Act & Assert
            await Assert.ThrowsAsync<BrendArgumentException>(() => service.GetBrendByNameAsync(brendName));
        }

        [Fact]
        public async Task UpdateBrendAsync_WhenBrendExists_ReturnsUpdatedBrendModel()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var brendRepositoryMock = new Mock<IBrendRepository>();
            var mapperMock = new Mock<IMapper>();

            var brendId = 1;
            var brendToUpdate = new Brend { Id = brendId, Name = "Old Name", Description = "Old Description" };
            var updatedBrendModel = new BrendModel { Id = brendId, Name = "New Name", Description = "New Description" };
            var updateModel = new UpdateBrendModel { Name = "New Name", Description = "New Description" };

            brendRepositoryMock.Setup(repo => repo.GetByIdAsync(brendId))
                .ReturnsAsync(brendToUpdate);
            unitOfWorkMock.SetupGet(uow => uow.IBrendRepository).Returns(brendRepositoryMock.Object);
            mapperMock.Setup(mapper => mapper.Map<BrendModel>(brendToUpdate))
                .Returns(updatedBrendModel);

            var service = new BrendService(unitOfWorkMock.Object, mapperMock.Object);

            // Act
            var result = await service.UpdateBrendAsync(brendId, updateModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(brendId, result.Id);
            Assert.Equal(updateModel.Name, result.Name);
            Assert.Equal(updateModel.Description, result.Description);
            brendRepositoryMock.Verify(repo => repo.Update(brendToUpdate), Times.Once);
            unitOfWorkMock.Verify(uow => uow.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task UpdateBrendAsync_WhenBrendDoesNotExist_ThrowsBrendArgumentException()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var brendRepositoryMock = new Mock<IBrendRepository>();

            var brendId = 1;
            var updateModel = new UpdateBrendModel { Name = "New Name", Description = "New Description" };

            brendRepositoryMock.Setup(repo => repo.GetByIdAsync(brendId))
                .ReturnsAsync((Brend)null);
            unitOfWorkMock.SetupGet(uow => uow.IBrendRepository).Returns(brendRepositoryMock.Object);

            var service = new BrendService(unitOfWorkMock.Object, Mock.Of<IMapper>());

            // Act & Assert
            await Assert.ThrowsAsync<BrendArgumentException>(() => service.UpdateBrendAsync(brendId, updateModel));
            brendRepositoryMock.Verify(repo => repo.Update(It.IsAny<Brend>()), Times.Never);
            unitOfWorkMock.Verify(uow => uow.SaveAsync(), Times.Never);
        }
    }
}
