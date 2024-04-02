using System.ComponentModel.DataAnnotations;
using WatchShop_Core.Domain.Enums;

namespace WatchShop_Core.Domain.Entities
{
    public class ClockFaceColor
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        public ClockFaceColorEnum Name { get; set; }
    }
}
