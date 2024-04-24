using AutoMapper;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.Payments.Request;
using WatchShop_Core.Models.Payments.Response;

namespace WatchShop_Core.Mappers
{
    public class PaymentModelProfile : Profile
    {
        public PaymentModelProfile()
        {
            CreateMap<CreatePaymentModel, Payment>();
            CreateMap<Payment, PaymentModel>();
        }
    }
}
