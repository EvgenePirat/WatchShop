using System.Text.Json.Serialization;
using WatchShop_UI.Dtos.Enums;

namespace WatchShop_UI.Dtos.FrameMaterials.Response
{
    public class FrameMaterialDto
    {
        public byte Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FrameMaterialEnum Name { get; set; }
    }
}
