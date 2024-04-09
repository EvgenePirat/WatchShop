using WatchShop_UI.Dtos.Enums;

namespace WatchShop_UI.Dtos.Straps.Request
{
    public class UpdateStrapDto
    {
        public int Id { get; set; }

        public StrapEnum Name { get; set; }

        public byte StrapMaterialId { get; set; }
    }
}
