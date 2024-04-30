using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchShop_Core.Models.Orders.Request;
using WatchShop_Core.Models.Shipments.Request;
using WatchShop_Core.ServiceContracts;
using WatchShop_UI.Dtos.Orders.Request;
using WatchShop_UI.Dtos.Orders.Response;
using WatchShop_UI.Dtos.Shipments.Request;
using WatchShop_UI.Utilities.GeneralResponse;

namespace WatchShop_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderService orderService, IMapper mapper, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ApiResponse>> CreateOrderAsync([FromBody] CreateOrderDto dto)
        {
            _logger.LogInformation("{controller}.{method} - Post, Create Order, Task started", nameof(OrderController), nameof(CreateOrderAsync));

            var mappedOrder = _mapper.Map<CreateOrderModel>(dto);

            var result = await _orderService.CreateOrderAsync(mappedOrder);

            var mappedResult = _mapper.Map<OrderDto>(result);

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.Created,
                Result = mappedResult
            };

            _logger.LogInformation("{controller}.{method} - Post, Create Order, Result - Ok, Task ended", nameof(OrderController), nameof(CreateOrderAsync));

            return Ok(response);
        }


        [HttpGet("all")]
        [Authorize]
        public async Task<ActionResult<ApiResponse>> GetOrdersAsync()
        {
            _logger.LogInformation("{controller}.{method} - Get, get all orders, Task started",
                nameof(OrderController), nameof(GetOrdersAsync));

            var result = await _orderService.GetAllOrdersAsync();

            var mappedResult = _mapper.Map<IEnumerable<OrderDto>>(result);

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Result = mappedResult
            };

            _logger.LogInformation("{controller}.{method} - Get, get all orders, Result - Ok, Task ended",
                nameof(OrderController), nameof(GetOrdersAsync));

            return Ok(response);
        }

        [HttpDelete("{id:Guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteOrderAsync(Guid id)
        {
            _logger.LogInformation("{controller}.{method} - Delete, delete order, Task started",
                nameof(OrderController), nameof(DeleteOrderAsync));

            await _orderService.DeleteOrderAsync(id);

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Result = $"Order {id} - was deleted"
            };

            _logger.LogInformation("{controller}.{method} - Delete, delete order, Result - Ok, Task ended",
                nameof(OrderController), nameof(DeleteOrderAsync));

            return Ok(response);
        }

        [HttpGet("{id:Guid}")]
        [Authorize]
        public async Task<ActionResult<ApiResponse>> GetOrderByIdAsync(Guid id)
        {
            _logger.LogInformation("{controller}.{method} - Get, get order by id, Task started",
                nameof(OrderController), nameof(GetOrderByIdAsync));

            var result = await _orderService.GetOrderByIdAsync(id);

            var mappedResult = _mapper.Map<OrderDto>(result);

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Result = mappedResult
            };

            _logger.LogInformation("{controller}.{method} - Get, get order by id, Result - Ok, Task ended",
                nameof(OrderController), nameof(GetOrderByIdAsync));

            return Ok(response);
        }

        [HttpPut("status/{id:Guid}&{newOrderStatus}")]
        [Authorize]
        public async Task<ActionResult<ApiResponse>> UpdateOrderStatusAsync(Guid id, string newOrderStatus)
        {
            _logger.LogInformation("{controller}.{method} - Post, Update order status, Task started",
                nameof(OrderController), nameof(UpdateOrderStatusAsync));

            var result = await _orderService.UpdateOrderStatusAsync(id, newOrderStatus);

            var mappedResult = _mapper.Map<OrderDto>(result);

            ApiResponse response = new ApiResponse()
            {
                Result = mappedResult,
                StatusCode = System.Net.HttpStatusCode.OK
            };

            _logger.LogInformation("{controller}.{method} - Post, Update Order status, Result - Ok, Task ended",
                nameof(OrderController), nameof(UpdateOrderStatusAsync));

            return Ok(response);
        }

        [HttpPut("shipment/{id:Guid}")]
        [Authorize]
        public async Task<ActionResult<ApiResponse>> UpdateOrderShipmentAsync(Guid id,[FromBody] UpdateShipmentDto dto)
        {
            _logger.LogInformation("{controller}.{method} - Post, Update shipment for order, Task started",
                nameof(OrderController), nameof(UpdateOrderStatusAsync));

            var model = _mapper.Map<UpdateShipmentModel>(dto);

            var result = await _orderService.UpdateShipmentAsync(id, model);

            var mappedResult = _mapper.Map<OrderDto>(result);

            ApiResponse response = new ApiResponse()
            {
                Result = mappedResult,
                StatusCode = System.Net.HttpStatusCode.OK
            };

            _logger.LogInformation("{controller}.{method} - Post, Update shipment for order, Result - Ok, Task ended",
                nameof(OrderController), nameof(UpdateOrderStatusAsync));

            return Ok(response);
        }

        [HttpGet("user/{username}")]
        [Authorize]
        public async Task<ActionResult<ApiResponse>> GetOrdersByUserNameAsync(string username)
        {
            _logger.LogInformation("{controller}.{method} - Get, get orders by username, Task started",
                nameof(OrderController), nameof(GetOrdersByUserNameAsync));

            var result = await _orderService.GetOrderByUserNameAsync(username);

            var mappedResult = _mapper.Map<IEnumerable<OrderDto>>(result);

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Result = mappedResult
            };

            _logger.LogInformation("{controller}.{method} - Get, get orders by username, Result - Ok, Task ended",
                nameof(OrderController), nameof(GetOrdersByUserNameAsync));

            return Ok(response);
        }
    }
}
