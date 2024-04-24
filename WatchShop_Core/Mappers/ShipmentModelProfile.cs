using AutoMapper;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.Shipments.Request;
using WatchShop_Core.Models.Shipments.Response;

namespace WatchShop_Core.Mappers
{
    public class ShipmentModelProfile : Profile
    {
        public ShipmentModelProfile()
        {
            CreateMap<CreateShipmentModel, Shipment>();
            CreateMap<UpdateShipmentModel, Shipment>();
            CreateMap<Shipment, ShipmentModel>();
        }
    }
}
