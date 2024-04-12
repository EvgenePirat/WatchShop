using System.ComponentModel.DataAnnotations;

namespace WatchShop_Core.Models.Images.Response
{
    public class ImageModel
    {
        public int Id { get; set; }

        public string? Path { get; set; }

        public DateTime UploadDateTime { get; set; }
    }
}
