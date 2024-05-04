using AutoMapper;
using Moq;
using System.Linq.Expressions;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Domain.Enums;
using WatchShop_Core.Domain.RepositoryContracts;
using WatchShop_Core.Exceptions;
using WatchShop_Core.Models.Orders.Request;
using WatchShop_Core.Models.Orders.Response;
using WatchShop_Core.Models.Payments.Request;
using WatchShop_Core.Models.Payments.Response;
using WatchShop_Core.Models.Shipments.Request;
using WatchShop_Core.Services;

namespace WatchShopTest.ModuleTests.CoreTest
{
    public class OrderServiceTests
    {
        [Fact]
        public async Task DeleteOrderAsync_OrderExists_DeletesOrderAndReturnsTrue()
        {
            // Arrange
            var orderId = Guid.NewGuid();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();

            var existingOrder = new Order { Id = orderId };
            unitOfWorkMock.Setup(uow => uow.OrderRepository.GetByIdAsync(orderId))
                         .ReturnsAsync(existingOrder);

            var orderService = new OrderService(unitOfWorkMock.Object, mapperMock.Object);

            // Act
            await orderService.DeleteOrderAsync(orderId);

            // Assert
            unitOfWorkMock.Verify(uow => uow.OrderRepository.Delete(existingOrder), Times.Once);
            unitOfWorkMock.Verify(uow => uow.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteOrderAsync_OrderDoesNotExist_ThrowsOrderArgumentException()
        {
            // Arrange
            var orderId = Guid.NewGuid();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();

            unitOfWorkMock.Setup(uow => uow.OrderRepository.GetByIdAsync(orderId))
                         .ReturnsAsync((Order)null); // Simulate order not found

            var orderService = new OrderService(unitOfWorkMock.Object, mapperMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<OrderArgumentException>(async () => await orderService.DeleteOrderAsync(orderId));
        }

        [Fact]
        public async Task GetAllOrdersAsync_ReturnsAllOrders()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();

            var orders = new List<Order>
            {
                new Order { Id = Guid.NewGuid(), Sum = 1000 },
                new Order { Id = Guid.NewGuid(), Sum = 500 },
            };

            unitOfWorkMock.Setup(uow => uow.OrderRepository.GetAllAsync(It.IsAny<Expression<Func<Order, object>>[]>()))
                         .ReturnsAsync(orders);

            mapperMock.Setup(mapper => mapper.Map<IEnumerable<OrderModel>>(orders))
                       .Returns(orders.Select(order => new OrderModel
                       {
                           Id = order.Id, 
                           Sum = order.Sum,
                       }));

            var orderService = new OrderService(unitOfWorkMock.Object, mapperMock.Object);

            // Act
            var result = await orderService.GetAllOrdersAsync();
            var resultList = result.ToList();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(orders.Count, result.Count());
            Assert.Equal(orders[0].Sum, resultList[0].Sum);
        }

        [Fact]
        public async Task GetOrderByIdAsync_ExistingOrderId_ReturnsOrderModel()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();

            var orderId = Guid.NewGuid();
            var order = new Order { Id = orderId,Sum = 500 };

            unitOfWorkMock.Setup(uow => uow.OrderRepository.GetByIdAsync(orderId))
                         .ReturnsAsync(order);

            var expectedOrderModel = new OrderModel
            {
                Id = orderId,
                Sum = 500
            };

            mapperMock.Setup(mapper => mapper.Map<OrderModel>(order))
                       .Returns(expectedOrderModel);

            var orderService = new OrderService(unitOfWorkMock.Object, mapperMock.Object);

            // Act
            var result = await orderService.GetOrderByIdAsync(orderId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedOrderModel.Id, result.Id);
            Assert.Equal(expectedOrderModel.Sum, result.Sum);
        }

        [Fact]
        public async Task CreateOrderAsync_ValidInput_ReturnsOrderModel()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();

            // Подготовка тестовых данных
            var createOrderModel = new CreateOrderModel
            {
                Sum = 200,
                Payment = new CreatePaymentModel { Amount = 200, PaymentMethod = (WatchShop_Core.Models.Enums.PaymentMethod)PaymentMethod.Card }
                // Дополните модель создания заказа при необходимости
            };

            var orderStatuses = new List<OrderStatus>
            {
                new OrderStatus { Id = 1, Name = OrderStatusEnum.Create },
                new OrderStatus { Id = 2, Name = OrderStatusEnum.Delivered }
            };

            unitOfWorkMock.Setup(uow => uow.OrderStatusRepositoryBase.GetAllAsync())
                         .ReturnsAsync(orderStatuses);

            var expectedOrder = new Order
            {
                Sum = 200,
                Payment = new Payment { Amount = 200, PaymentMethod = PaymentMethod.Card },
                OrderStatusId = 1
            };

            var expectedOrderModel = new OrderModel
            {
                Sum = 200
            };

            unitOfWorkMock.Setup(uow => uow.OrderRepository.Add(It.IsAny<Order>()))
                         .Callback<Order>(order =>
                         {
                             Assert.Equal(expectedOrder.Sum, order.Sum);
                             Assert.Equal(expectedOrder.Payment.Amount, order.Payment.Amount);
                         });

            mapperMock.Setup(mapper => mapper.Map<Order>(createOrderModel))
                      .Returns(expectedOrder);

            mapperMock.Setup(mapper => mapper.Map<OrderModel>(expectedOrder))
                      .Returns(expectedOrderModel);

            var orderService = new OrderService(unitOfWorkMock.Object, mapperMock.Object);

            // Act
            var result = await orderService.CreateOrderAsync(createOrderModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createOrderModel.Sum, expectedOrderModel.Sum);
        }

        [Fact]
        public async Task GetOrderByUserNameAsync_ValidUsername_ReturnsOrderModels()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();

            var username = "testUser";
            var orders = new List<Order>
            {
                new Order { Sum = 200, Comment = "Top JFKEfhds" },
                new Order {  Sum = 300, Comment = "Top JFKEfhds" },
            };

            unitOfWorkMock.Setup(uow => uow.OrderRepository.FindOrdersByUserNameAsync(username))
                         .ReturnsAsync(orders);

            var expectedOrderModels = orders.Select(order => new OrderModel
            {
                Sum = order.Sum,
                Comment = order.Comment
            });

            mapperMock.Setup(mapper => mapper.Map<IEnumerable<OrderModel>>(orders))
                       .Returns(expectedOrderModels);

            var orderService = new OrderService(unitOfWorkMock.Object, mapperMock.Object);

            // Act
            var result = await orderService.GetOrderByUserNameAsync(username);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(orders.Count, result.Count());
        }
    }
}
