﻿using AutoMapper;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Domain.RepositoryContracts;
using WatchShop_Core.Exceptions;
using WatchShop_Core.Models.Orders.Request;
using WatchShop_Core.Models.Orders.Response;
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

            mappedEntity.OrderStatusId = orderStatuses.FirstOrDefault(os => os.Name.Value == Domain.Enums.OrderStatusEnum.Processing).Id;

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
            var orders = await _unitOfWork.OrderRepository.GetAllAsync(o => o.Carts, o => o.OrderStatus);
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
    }
}