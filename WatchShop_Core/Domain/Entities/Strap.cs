using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchShop_Core.Domain.Enums;

namespace WatchShop_Core.Domain.Entities
{
    public class Strap
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        public StrapEnum Name { get; set; }

        [Required]  
        public byte StrapMaterialId { get; set; }

        [ForeignKey("StrapMaterialId")]
        public StrapMaterial? StrapMaterial { get; set; }
    }
}
