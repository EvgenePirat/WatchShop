using System.ComponentModel.DataAnnotations;
using WatchShop_Core.Domain.Enums;

namespace WatchShop_Core.Domain.Entities
{
    public class IndicationType
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        public IndicationTypeEnum Name { get; set; }
    }
}
