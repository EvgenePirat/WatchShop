using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WatchShop_Core.Domain.Entities
{
    public class WatchAdditionalCharacteristics
    {
        [Key]
        public int WatchId { get; set; }

        [ForeignKey("WatchId")]
        public Watch Watch { get; set; }

        public int AdditionalCharacteristicsId { get; set; }

        [ForeignKey("AdditionalCharacteristicsId")]
        public AdditionalCharacteristics AdditionalCharacteristic { get; set; }
    }
}
