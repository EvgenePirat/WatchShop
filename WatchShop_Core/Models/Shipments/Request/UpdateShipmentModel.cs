namespace WatchShop_Core.Models.Shipments.Request
{
    public class UpdateShipmentModel
    {
        public string Address { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }
    }
}
