using WatchShop_Core.Models.Enums;

namespace WatchShop_Core.Models.Payments.Request
{
    public class CreatePaymentModel
    {
        public DateTime PaymentDate { get; set; } = DateTime.Now;

        public string? StripeIntendId { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public PaymentStatus Status { get; set; } = PaymentStatus.Paid;

        public double Amount { get; set; }

        public Guid ApplicationUserId { get; set; }
    }
}
