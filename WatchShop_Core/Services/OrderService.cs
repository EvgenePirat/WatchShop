using AutoMapper;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Domain.Enums;
using WatchShop_Core.Domain.RepositoryContracts;
using WatchShop_Core.Exceptions;
using WatchShop_Core.Models.Orders.Request;
using WatchShop_Core.Models.Orders.Response;
using WatchShop_Core.Models.Shipments.Request;
using WatchShop_Core.ServiceContracts;

namespace WatchShop_Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<OrderModel> CreateOrderAsync(CreateOrderModel model)
        {
            var mappedEntity = _mapper.Map<Order>(model);

            var orderStatuses = await _unitOfWork.OrderStatusRepositoryBase.GetAllAsync();

            mappedEntity.OrderStatusId = orderStatuses.FirstOrDefault(os => os.Name.Value == OrderStatusEnum.Create).Id;

            if (mappedEntity.Sum > mappedEntity.Payment.Amount)
                throw new OrderArgumentException("Sum order not equals payment amount");

            if(mappedEntity.Payment.PaymentMethod == PaymentMethod.Card)
            {
                mappedEntity.Payment.Status = PaymentStatus.Paid;
            }
            else
            {
                mappedEntity.Payment.Status = PaymentStatus.Upon_Receipt;
            }

            _unitOfWork.OrderRepository.Add(mappedEntity);

            await _unitOfWork.SaveAsync();

            return _mapper.Map<OrderModel>(mappedEntity);
        }

        public async Task DeleteOrderAsync(Guid id)
        {
            var orderToDelete = await _unitOfWork.OrderRepository.GetByIdAsync(id);

            if (orderToDelete == null)
                throw new OrderArgumentException($"Order by id {id} not found for delete");

            _unitOfWork.OrderRepository.Delete(orderToDelete);

            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<OrderModel>> GetAllOrdersAsync()
        {
            var orders = await _unitOfWork.OrderRepository.GetAllAsync(o => o.Carts, o => o.OrderStatus, o => o.Shipment, o => o.Payment);
            return _mapper.Map<IEnumerable<OrderModel>>(orders);
        }

        public async Task<OrderModel> GetOrderByIdAsync(Guid id)
        {
            var order = await _unitOfWork.OrderRepository.GetByIdAsync(id) ?? throw new OrderArgumentException($"Order by {id} not found");
            return _mapper.Map<OrderModel>(order);
        }

        public async Task<IEnumerable<OrderModel>> GetOrderByUserNameAsync(string username)
        {
            var orders = await _unitOfWork.OrderRepository.FindOrdersByUserNameAsync(username);
            return _mapper.Map<IEnumerable<OrderModel>>(orders);
        }

        public async Task<OrderModel> UpdateOrderStatusAsync(Guid id, string newOrderStatus)
        {
            var orderToUpdate = await _unitOfWork.OrderRepository.GetByIdAsync(id);

            if (orderToUpdate == null)
                throw new OrderArgumentException($"Order by id {id} not found for update");

            var orderStatuses = await _unitOfWork.OrderStatusRepositoryBase.GetAllAsync();

            if(orderToUpdate.OrderStatus.Name == OrderStatusEnum.Cancelled || orderToUpdate.OrderStatus.Name == OrderStatusEnum.Delivered)
            {
                throw new OrderArgumentException("You can not update status for order, order was cancelled or delivered. You need create new order");
            }
            
            try
            {
                var newStatusName = Enum.Parse<OrderStatusEnum>(newOrderStatus);

                orderToUpdate.OrderStatusId = orderStatuses.FirstOrDefault(os => os.Name == newStatusName).Id;

                if(newStatusName == OrderStatusEnum.Cancelled)
                {
                    orderToUpdate.Payment.Status = PaymentStatus.Refund;
                }

                _unitOfWork.OrderRepository.Update(orderToUpdate);

                await _unitOfWork.SaveAsync();

                return _mapper.Map<OrderModel>(orderToUpdate);
            }
            catch(Exception ex)
            {
                throw new OrderStatusArgumentException(ex.Message);
            }
        }

        public async Task<OrderModel> UpdateShipmentAsync(Guid id, UpdateShipmentModel model)
        {
            var orderToUpdate = await _unitOfWork.OrderRepository.GetByIdAsync(id);

            if (orderToUpdate == null)
                throw new OrderArgumentException($"Order by id {id} not found for update");

            if (orderToUpdate.OrderStatus.Name == OrderStatusEnum.Cancelled || orderToUpdate.OrderStatus.Name == OrderStatusEnum.Delivered)
            {
                throw new OrderArgumentException("You can not update shipment for order, order was cancelled or delivered.");
            }

            var orderStatuses = await _unitOfWork.OrderStatusRepositoryBase.GetAllAsync();

            try
            {
                orderToUpdate.Shipment.Address = model.Address;
                orderToUpdate.Shipment.Country = model.Country;
                orderToUpdate.Shipment.City = model.City;

                _unitOfWork.OrderRepository.Update(orderToUpdate);

                await _unitOfWork.SaveAsync();

                return _mapper.Map<OrderModel>(orderToUpdate);
            }
            catch (Exception ex)
            {
                throw new OrderStatusArgumentException(ex.Message);
            }
        }
    }
}
