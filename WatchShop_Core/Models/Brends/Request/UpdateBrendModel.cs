using System.ComponentModel.DataAnnotations;

namespace WatchShop_Core.Models.Brends.Request
{
    public class UpdateBrendModel
    {
        [Required(ErrorMessage = "Name must be not null")]
        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}
