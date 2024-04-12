using WatchShop_Core.Models.Enums;

namespace WatchShop_Core.Models.Straps.Request
{
    public class CreateStrapModel
    {
        public StrapEnum Name { get; set; }

        public byte StrapMaterialId { get; set; }
    }
}
