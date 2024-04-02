using System.ComponentModel.DataAnnotations;
using WatchShop_Core.Domain.Enums;

namespace WatchShop_Core.Domain.Entities
{
    public class IndicationKind
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        public IndicationKindEnum Name { get; set; }
    }
}
