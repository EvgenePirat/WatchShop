using WatchShop_Core.Models.SalesStatistics.Response;

namespace WatchShop_Core.ServiceContracts
{
    public interface IAnalyticService
    {
        Task<SalesStatisticModel> CalculateSalesStatisticsAsync();
    }
}
