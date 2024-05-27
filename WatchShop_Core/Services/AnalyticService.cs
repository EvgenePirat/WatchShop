using System.Linq;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Domain.RepositoryContracts;
using WatchShop_Core.Models.SalesStatistics.Response;
using WatchShop_Core.ServiceContracts;

namespace WatchShop_Core.Services
{
    public class AnalyticService : IAnalyticService
    {
        private IUnitOfWork _unitOfWork;
        private int _daysAgo = -10;

        public AnalyticService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SalesStatisticModel> CalculateSalesStatisticsAsync()
        {
            var startDate = DateTime.Now.Date.AddDays(_daysAgo);
            var endDate = DateTime.Now.Date.AddHours(+1);
            Dictionary<DateTime, int> salesByDay = new Dictionary<DateTime, int>();

            var orders = await _unitOfWork.OrderRepository.GetAllAsync(o => o.OrderStatus, o => o.Carts);
            var needOrders = orders.Where(o => o.CreateDate.Date >= startDate.Date && o.CreateDate.Date <= endDate.Date)
                .Where(o => o.OrderStatus.Name == Domain.Enums.OrderStatusEnum.Delivered)
                .ToList();

            if (needOrders.Count == 0)
            {
                for (int i = 0; i > 4; i++)
                {
                    _daysAgo = _daysAgo + (-10);
                    startDate = DateTime.Now.Date.AddDays(_daysAgo);
                    needOrders = orders.Where(o => o.CreateDate.Date > startDate.Date && o.CreateDate.Date <= endDate.Date)
                        .Where(o => o.OrderStatus.Name == Domain.Enums.OrderStatusEnum.Delivered)
                        .ToList();

                    if (needOrders.Count > 0)
                    {
                        break;
                    }
                }
            }

            CountingOrdersAndDays(startDate, endDate, salesByDay, orders);

            var statistics = new SalesStatisticModel();

            SetStatistics(salesByDay, orders, needOrders, statistics);

            return statistics;
        }

        private void SetStatistics(Dictionary<DateTime, int> salesByDay, IEnumerable<Order> orders, List<Order> needOrders, SalesStatisticModel statistics)
        {
            statistics.TotalSales = needOrders.Count == 0 ? 0 : needOrders.Count;
            statistics.TotalRevenue = needOrders.Sum(o => o.Sum);
            statistics.AverageOrderValue = statistics.TotalSales != 0 ? statistics.TotalRevenue / statistics.TotalSales : 0;
            statistics.TotalOrdersInProgress = orders.Count(o => o.OrderStatus.Name == Domain.Enums.OrderStatusEnum.Processing);
            statistics.TotalOrdersInCreate = orders.Count(o => o.OrderStatus.Name == Domain.Enums.OrderStatusEnum.Create);
            statistics.DaysAgo = _daysAgo;
            statistics.SalesByDay = salesByDay;
        }

        private static void CountingOrdersAndDays(DateTime startDate, DateTime endDate, Dictionary<DateTime, int> salesByDay, IEnumerable<Order> orders)
        {
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                var ordersForDay = orders.Where(o => o.CreateDate.Date == date.Date);

                int salesForDay = ordersForDay.Count();

                salesByDay.Add(date, salesForDay);
            }
        }
    }
}
