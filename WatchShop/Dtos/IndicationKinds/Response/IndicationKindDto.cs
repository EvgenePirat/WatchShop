using System.Text.Json.Serialization;
using WatchShop_UI.Dtos.Enums;

namespace WatchShop_UI.Dtos.IndicationKinds.Response
{
    public class IndicationKindDto
    {
        public byte Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public IndicationKindEnum Name { get; set; }
    }
}
