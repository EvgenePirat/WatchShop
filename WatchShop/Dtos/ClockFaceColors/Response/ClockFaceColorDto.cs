using System.Text.Json.Serialization;
using WatchShop_UI.Dtos.Enums;

namespace WatchShop_UI.Dtos.ClockFaceColors.Response
{
    public class ClockFaceColorDto
    {
        public byte Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ClockFaceColorEnum Name { get; set; }
    }
}
