﻿using System.ComponentModel.DataAnnotations;
using WatchShop_Core.Domain.Enums;

namespace WatchShop_Core.Domain.Entities
{
    public class FrameMaterial
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        public FrameMaterialEnum Name { get; set; }
    }
}
