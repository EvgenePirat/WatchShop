﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchShop_Core.Domain.Enums;

namespace WatchShop_Core.Domain.Entities
{
    [Table("frame_colors")]
    public class FrameColor
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        public FrameColorEnum Name { get; set; }


    }
}
