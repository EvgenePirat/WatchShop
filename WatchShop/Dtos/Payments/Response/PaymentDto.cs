using System.Text.Json.Serialization;
using WatchShop_UI.Dtos.Enums;

namespace WatchShop_UI.Dtos.Payments.Response
{
    public class PaymentDto
    {
        public Guid Id { get; set; }

        public DateTime PaymentDate { get; set; }

        public string? StripeIntendId { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PaymentMethod PaymentMethod { get; set; }

        public double Amount { get; set; }

        public Guid ApplicationUserId { get; set; }
    }
}
