using WatchShop_Core.Models.Payments.Response;

namespace WatchShop_Core.ServiceContracts
{
    public interface IPaymentService
    {
         PaymentIntentModel CreatePayment(double carttotal);
    }
}
