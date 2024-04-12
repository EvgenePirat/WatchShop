using WatchShop_Core.Models.Enums;

namespace WatchShop_Core.Models.Styles.Response
{
    public class StyleModel
    {
        public byte Id { get; set; }

        public StyleEnum Name { get; set; }

        public string? Description { get; set; }
    }
}
