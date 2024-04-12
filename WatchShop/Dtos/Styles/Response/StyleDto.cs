using System.Text.Json.Serialization;
using WatchShop_UI.Dtos.Enums;

namespace WatchShop_UI.Dtos.Styles.Response
{
    public class StyleDto
    {
        public byte Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StyleEnum Name { get; set; }

        public string? Description { get; set; }
    }
}
