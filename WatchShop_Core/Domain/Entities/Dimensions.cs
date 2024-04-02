using System.ComponentModel.DataAnnotations;
using WatchShop_Core.Domain.Enums;

namespace WatchShop_Core.Domain.Entities
{
    public class Dimensions
    {
        [Key]
        public int Id { get; set; }

        public double? Length { get; set; }

        public double? Thickness { get; set; }

        public double? Width { get; set; }

        public double? Weight { get; set; }

        [Required]
        public CaseDiameter CaseDiameter { get; set; }
    }
}
