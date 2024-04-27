using AutoMapper;
using WatchShop_Core.Models.SalesStatistics.Response;
using WatchShop_UI.Dtos.SalesStatistics.Response;

namespace WatchShop_UI.Mappers
{
    public class AnalyticDtoProfile : Profile
    {
        public AnalyticDtoProfile()
        {
            CreateMap<SalesStatisticModel, SalesStatisticDto>();
        }
    }
}
