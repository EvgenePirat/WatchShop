using Microsoft.EntityFrameworkCore;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Domain.RepositoryContracts;
using WatchShop_Infrastructure.DbContext;
using WatchShop_Infrastructure.Utilities;

namespace WatchShop_Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Order>> FindOrdersByUserNameAsync(string username)
        {
            var orders = await _context.Orders.IncludeMultiple(o => o.OrderStatus, o => o.Carts, o => o.Shipment, o => o.User).ToListAsync();
            return orders.FindAll(o => o.User.UserName == username);
        }

        public async Task<Order?> GetByIdAsync(Guid id)
        {
            return await _context.Orders.IncludeMultiple(o => o.OrderStatus, o => o.Carts, o => o.User, o => o.Shipment).FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
