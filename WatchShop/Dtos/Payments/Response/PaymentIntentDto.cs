namespace WatchShop_UI.Dtos.Payments.Response
{
    public class PaymentIntentDto
    {
        public string StripePaymentIntentId { get; set; }

        public string ClientSecret { get; set; }
    }
}
