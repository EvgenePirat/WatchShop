using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.Enums;
using WatchShop_Core.Models.StrapMaterials.Response;

namespace WatchShop_Core.Models.Straps.Response
{
    public class StrapModel
    {
        public int Id { get; set; }

        public StrapEnum Name { get; set; }

        public StrapMaterialModel? StrapMaterial { get; set; }
    }
}
