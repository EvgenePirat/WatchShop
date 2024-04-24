using System.ComponentModel.DataAnnotations;

namespace WatchShop_UI.Dtos.Shipments.Request
{
    public class CreateShipmentDto
    {
        [Required] 
        public string Address { get; set; }

        [Required]
        public string? City { get; set; }

        [Required]
        public string? Country { get; set; }

        [Required]
        public Guid ApplicationUserId { get; set; }
    }
}
