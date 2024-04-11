using WatchShop_Core.Models.Brends.Response;
using WatchShop_Core.Models.Orders.Request;
using WatchShop_Core.Models.Orders.Response;

namespace WatchShop_Core.ServiceContracts
{
    public interface IOrderService 
    {
        Task<OrderModel> CreateOrderAsync(CreateOrderModel model);

        Task<IEnumerable<OrderModel>> GetAllOrdersAsync();

        Task DeleteOrderAsync(Guid id);

        Task<IEnumerable<OrderModel>> GetOrderByUserNameAsync(string username);

        Task<OrderModel> GetOrderByIdAsync(Guid id);
    }
}
