using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchShop_Core.Domain.Enums;

namespace WatchShop_Core.Domain.Entities
{
    [Table("additional_characteristics")]
    public class AdditionalCharacteristics
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public AdditionalCharacteristicsEnum Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public IEnumerable<WatchAdditionalCharacteristic>? WatchAdditionalCharacteristics { get; set; }
    }
}
