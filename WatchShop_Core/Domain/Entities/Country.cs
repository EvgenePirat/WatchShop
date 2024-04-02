using System.ComponentModel.DataAnnotations;
using WatchShop_Core.Domain.Enums;

namespace WatchShop_Core.Domain.Entities
{
    public class Country
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        public CountryEnum Name { get; set; }
    }
}
