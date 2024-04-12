using System.Text.Json.Serialization;
using WatchShop_UI.Dtos.Enums;

namespace WatchShop_UI.Dtos.StrapMaterials.Response
{
    public class StrapMaterialDto
    {
        public byte Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StrapMaterialEnum Name { get; set; }
    }
}
