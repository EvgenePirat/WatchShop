namespace WatchShop_UI.Dtos.Shipments.Response
{
    public class ShipmentDto
    {
        public Guid Id { get; set; }

        public string Address { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }

        public Guid ApplicationUserId { get; set; }
    }
}
