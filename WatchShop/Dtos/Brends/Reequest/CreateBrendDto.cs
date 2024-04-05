using System.ComponentModel.DataAnnotations;

namespace WatchShop_UI.Dtos.Brends.Reequest
{
    public class CreateBrendDto
    {
        [Required(ErrorMessage = "Name must be not null")]
        public string Name { get; set; }

        public string? Description { get; set; }
    }
}
