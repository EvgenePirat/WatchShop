using WatchShop_UI.Dtos.Enums;

namespace WatchShop_UI.Dtos.Styles.Response
{
    public class StyleDto
    {
        public byte Id { get; set; }

        public StyleEnum Name { get; set; }

        public string? Description { get; set; }
    }
}
