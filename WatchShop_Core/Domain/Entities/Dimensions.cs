using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchShop_Core.Domain.Contracts;
using WatchShop_Core.Domain.Enums;

namespace WatchShop_Core.Domain.Entities
{
    [Table("dimensions")]
    public class Dimension : IEntity
    {
        [Key]
        public int Id { get; set; }

        public double? Length { get; set; }

        public double? Thickness { get; set; }

        public double? Width { get; set; }

        public double? Weight { get; set; }

        [Required]
        public CaseDiameter CaseDiameter { get; set; }

        public IEnumerable<Frame>? Frames { get; set; }
    }
}
