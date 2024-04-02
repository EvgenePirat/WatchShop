using System.ComponentModel.DataAnnotations;
using WatchShop_Core.Domain.Enums;

namespace WatchShop_Core.Domain.Entities
{
    public class FrameColor
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        public FrameColorEnum Name { get; set; }

    }
}
