using WatchShop_Core.Models.Enums;

namespace WatchShop_Core.Models.GlassTypes.Response
{
    public class GlassTypeModel
    {
        public byte Id { get; set; }

        public GlassTypeEnum Name { get; set; }

        public string? Description { get; set; }
    }
}
