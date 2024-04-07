using WatchShop_Core.Models.StrapMaterials.Response;
using WatchShop_UI.Dtos.Enums;
using WatchShop_UI.Dtos.StrapMaterials.Response;

namespace WatchShop_UI.Dtos.Straps.Response
{
    public class StrapDto
    {
        public byte Id { get; set; }

        public StrapEnum Name { get; set; }

        public StrapMaterialDto? StrapMaterial { get; set; }
    }
}
