using Moq;
using System.Linq.Expressions;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Domain.Enums;
using WatchShop_Core.Domain.RepositoryContracts;
using WatchShop_Core.Services;

namespace WatchShopTest.ModuleTests.CoreTest
{
    public class AnalyticServiceTests
    {
        [Fact]
        public async Task CalculateSalesStatisticsAsync_ReturnsStatistics()
        {
            // Arrange
            var orders = new List<Order>
            {
                new Order { CreateDate = DateTime.Now.Date, OrderStatus = new OrderStatus { Name = OrderStatusEnum.Delivered }, Sum = 100 },
                new Order { CreateDate = DateTime.Now.Date.AddDays(-2), OrderStatus = new OrderStatus { Name = OrderStatusEnum.Delivered }, Sum = 200 },
                new Order { CreateDate = DateTime.Now.Date.AddDays(-4), OrderStatus = new OrderStatus { Name = OrderStatusEnum.Delivered }, Sum = 300 }
            };

            var orderRepositoryMock = new Mock<IOrderRepository>();
            orderRepositoryMock.Setup(repo => repo.GetAllAsync(It.IsAny<Expression<Func<Order, object>>[]>()))
                               .ReturnsAsync(orders);

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(uow => uow.OrderRepository)
                          .Returns(orderRepositoryMock.Object);

            var analyticService = new AnalyticService(unitOfWorkMock.Object);

            // Act
            var result = await analyticService.CalculateSalesStatisticsAsync();

            // Assert
            Assert.Equal(3, result.TotalSales);
        }
    }
}
