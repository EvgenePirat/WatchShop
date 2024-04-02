using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WatchShop_Core.Domain.Entities
{
    public class ClockFace
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public byte IndicationTypeId { get; set; }

        [ForeignKey("IndicationTypeId")]
        public IndicationType? IndicationType { get; set; }

        [Required]
        public byte IndicationKindId { get; set; }

        [ForeignKey("IndicationKindId")]
        public IndicationKind? IndicationKind { get; set; }

        [Required]
        public byte ClockFaceColorId { get; set; }

        [ForeignKey("ClockFaceColorId")]
        public ClockFaceColor? ClockFaceColor { get; set; }

    }
}
