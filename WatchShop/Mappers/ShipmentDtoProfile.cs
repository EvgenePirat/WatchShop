using AutoMapper;
using WatchShop_Core.Models.Shipments.Request;
using WatchShop_Core.Models.Shipments.Response;
using WatchShop_UI.Dtos.Shipments.Request;
using WatchShop_UI.Dtos.Shipments.Response;

namespace WatchShop_UI.Mappers
{
    public class ShipmentDtoProfile : Profile
    {
        public ShipmentDtoProfile()
        {
            CreateMap<ShipmentModel, ShipmentDto>();
            CreateMap<CreateShipmentDto, CreateShipmentModel>();
            CreateMap<UpdateShipmentDto, UpdateShipmentModel>();
        }
    }
}
