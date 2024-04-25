namespace WatchShop_UI.Dtos.Payments.Request
{
    public class CreatePaymentDto
    {
        public string? StripeIntendId { get; set; }

        public string PaymentMethod { get; set; }

        public double Amount { get; set; }

        public Guid ApplicationUserId { get; set; }
    }
}
