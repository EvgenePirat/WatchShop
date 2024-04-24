namespace WatchShop_Core.Models.Payments.Response
{
    public class PaymentIntentModel
    {
        public string StripePaymentIntentId { get; set; }

        public string ClientSecret { get; set; }
    }
}
