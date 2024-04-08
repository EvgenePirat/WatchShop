using System.Text.Json.Serialization;
using WatchShop_UI.Dtos.Enums;
using WatchShop_UI.Dtos.StrapMaterials.Response;

namespace WatchShop_UI.Dtos.Straps.Response
{
    public class StrapDto
    {
        public byte Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StrapEnum Name { get; set; }

        public StrapMaterialDto? StrapMaterial { get; set; }
    }
}
