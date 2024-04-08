using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchShop_Core.Domain.Contracts;
using WatchShop_Core.Domain.Enums;

namespace WatchShop_Core.Domain.Entities
{
    [Table("indication_kinds")]
    public class IndicationKind : IEntity
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        public IndicationKindEnum Name { get; set; }

        public IEnumerable<ClockFace>? ClockFaces { get; set; }
    }
}
