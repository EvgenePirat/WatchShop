using AutoMapper;
using Moq;
using System.Linq.Expressions;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Domain.RepositoryContracts;
using WatchShop_Core.Models.Watches.Request;
using WatchShop_Core.Models.Watches.Response;
using WatchShop_Core.ServiceContracts;
using WatchShop_Core.Services;

namespace WatchShopTest.ModuleTests.CoreTest
{
    public class WatchServiceTests
    {
        [Fact]
        public async Task GetByNameModelAsync_WatchExists_ReturnsWatchModel()
        {
            // Arrange
            var nameModel = "ExampleModel";
            var expectedWatch = new Watch { NameModel = nameModel };

            var watchRepositoryMock = new Mock<IWatchRepository>();
            watchRepositoryMock.Setup(repo => repo.FindByNameModelAsync(nameModel))
                              .ReturnsAsync(expectedWatch);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<WatchModel>(expectedWatch))
                      .Returns(new WatchModel { NameModel = expectedWatch.NameModel }); // Adjust this based on the mapping logic

            var blobServiceMock = new Mock<IBlobService>();

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(uow => uow.WatchRepository)
                          .Returns(watchRepositoryMock.Object);

            var watchService = new WatchService(blobServiceMock.Object, unitOfWorkMock.Object, mapperMock.Object);

            // Act
            var result = await watchService.GetByNameModelAsync(nameModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedWatch.NameModel, result.NameModel);
        }

        [Fact]
        public async Task GetAllWatchesAsync_ReturnsListOfWatchModels()
        {
            // Arrange
            var expectedWatches = new List<Watch>
            {
                new Watch { Id = 1, NameModel = "Watch1" },
                new Watch { Id = 2, NameModel = "Watch2" },
                new Watch { Id = 3, NameModel = "Watch3" }
            };

            var watchRepositoryMock = new Mock<IWatchRepository>();
            watchRepositoryMock.Setup(repo => repo.GetAllAsync(
                    It.IsAny<Expression<Func<Watch, object>>[]>()))
                .ReturnsAsync(expectedWatches);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<IEnumerable<WatchModel>>(expectedWatches))
                      .Returns(expectedWatches.Select(watch => new WatchModel { Id = watch.Id, NameModel = watch.NameModel })); // Adjust this based on the mapping logic

            var blobServiceMock = new Mock<IBlobService>();

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(uow => uow.WatchRepository)
                          .Returns(watchRepositoryMock.Object);

            var watchService = new WatchService(blobServiceMock.Object, unitOfWorkMock.Object, mapperMock.Object);

            // Act
            var result = await watchService.GetAllWatchesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedWatches.Count, result.Count());

            // Check if each expected watch is present in the result
            foreach (var expectedWatch in expectedWatches)
            {
                Assert.Contains(result, watch => watch.Id == expectedWatch.Id && watch.NameModel == expectedWatch.NameModel);
            }
        }

        [Fact]
        public async Task GetByNameModelAsync_ExistingNameModel_ReturnsWatchModel()
        {
            // Arrange
            var nameModel = "ExampleWatchModel";
            var expectedWatch = new Watch
            {
                NameModel = nameModel,
            };

            var watchRepositoryMock = new Mock<IWatchRepository>();
            watchRepositoryMock.Setup(repo => repo.FindByNameModelAsync(nameModel))
                              .ReturnsAsync(expectedWatch);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<WatchModel>(expectedWatch))
                      .Returns(new WatchModel
                      {
                          NameModel = expectedWatch.NameModel,
                      });

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(uow => uow.WatchRepository)
                          .Returns(watchRepositoryMock.Object);

            var blobServiceMock = new Mock<IBlobService>();

            var watchService = new WatchService(blobServiceMock.Object, unitOfWorkMock.Object, mapperMock.Object);

            // Act
            var result = await watchService.GetByNameModelAsync(nameModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedWatch.NameModel, result.NameModel);
        }

  
    }
}
