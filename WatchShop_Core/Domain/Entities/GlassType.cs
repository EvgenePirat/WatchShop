using System.ComponentModel.DataAnnotations;
using WatchShop_Core.Domain.Enums;

namespace WatchShop_Core.Domain.Entities
{
    public class GlassType
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        public GlassTypeEnum Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
