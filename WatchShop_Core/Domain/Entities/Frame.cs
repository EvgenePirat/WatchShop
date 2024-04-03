using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchShop_Core.Domain.Enums;

namespace WatchShop_Core.Domain.Entities
{
    [Table("Frames")]
    public class Frame
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public CaseShape CaseShape { get; set; }

        [Required]
        public WaterResistance WaterResistance { get; set; }

        [Required]
        public byte FrameMaterialId { get; set; }

        [ForeignKey("FrameMaterialId")]
        public FrameMaterial? FrameMaterial { get; set; }

        [Required]
        public byte FrameColorId { get; set; }

        [ForeignKey("FrameColorId")]
        public FrameColor? FrameColor { get; set; }

        [Required]
        public int DimensionsId { get; set; }

        [ForeignKey("DimensionsId")]
        public Dimension? Dimensions { get; set; }

        public IEnumerable<Watch>? Watches { get; set; }
    }
}
