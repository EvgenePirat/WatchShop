namespace WatchShop_Core.Models.Shipments.Request
{
    public class CreateShipmentModel
    {
        public string Address { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }

        public Guid ApplicationUserId { get; set; }
    }
}
