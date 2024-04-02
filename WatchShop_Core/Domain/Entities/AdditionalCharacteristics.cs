using System.ComponentModel.DataAnnotations;
using WatchShop_Core.Domain.Enums;

namespace WatchShop_Core.Domain.Entities
{
    public class AdditionalCharacteristics
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public AdditionalCharacteristicsEnum Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public IEnumerable<WatchAdditionalCharacteristics>? WatchAdditionalCharacteristics { get; set; }
    }
}
