using WatchShop_UI.Dtos.Enums;

namespace WatchShop_UI.Dtos.Straps.Request
{
    public class CreateStrapDto
    {
        public string Name { get; set; }

        public byte StrapMaterialId { get; set; }
    }
}
