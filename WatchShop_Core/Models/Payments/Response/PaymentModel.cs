using WatchShop_Core.Models.Enums;

namespace WatchShop_Core.Models.Payments.Response
{
    public class PaymentModel
    {
        public Guid Id { get; set; }

        public DateTime PaymentDate { get; set; }

        public string? StripeIntendId { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public double Amount { get; set; }

        public Guid ApplicationUserId { get; set; }
    }
}
