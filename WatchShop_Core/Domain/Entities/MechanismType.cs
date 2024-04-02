using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop_Core.Domain.Enums;

namespace WatchShop_Core.Domain.Entities
{
    public class MechanismType
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        public MechanismTypeEnum Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }
    }
}
