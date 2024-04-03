using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WatchShop_Core.Domain.Entities
{
    [Table("watch_additional_characteristics")]
    public class WatchAdditionalCharacteristics
    {
        public int WatchId { get; set; }

        [ForeignKey("WatchId")]
        public Watch Watch { get; set; }

        public int AdditionalCharacteristicsId { get; set; }

        [ForeignKey("AdditionalCharacteristicsId")]
        public AdditionalCharacteristics AdditionalCharacteristics { get; set; }
    }
}
