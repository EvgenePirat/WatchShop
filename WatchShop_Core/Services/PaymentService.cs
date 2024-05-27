using Microsoft.Extensions.Configuration;
using Stripe;
using WatchShop_Core.Models.Payments.Response;
using WatchShop_Core.ServiceContracts;

namespace WatchShop_Core.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;
        private const int conversionRate = 100;

        public PaymentService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public PaymentIntentModel CreatePayment(double carttotal)
        {
            StripeConfiguration.ApiKey = _configuration["StripeSettings:SecretKey"];

            var options = new PaymentIntentCreateOptions
            {
                Amount = (int)(carttotal * conversionRate),
                Currency = "usd",
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },
            };

            var service = new PaymentIntentService();
            PaymentIntent response = service.Create(options);

            PaymentIntentModel result = new()
            {
                StripePaymentIntentId = response.Id,
                ClientSecret = response.ClientSecret,
            };

            return result;
        }
    }
}
