using AutoMapper;
using WatchShop_Core.Models.Payments.Request;
using WatchShop_Core.Models.Payments.Response;
using WatchShop_UI.Dtos.Payments.Request;
using WatchShop_UI.Dtos.Payments.Response;

namespace WatchShop_UI.Mappers
{
    public class PaymentDtoProfile : Profile
    {
        public PaymentDtoProfile()
        {
            CreateMap<CreatePaymentDto, CreatePaymentModel>();
            CreateMap<PaymentModel, PaymentDto>();
        }
    }
}
