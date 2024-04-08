using System.Text.Json.Serialization;
using WatchShop_UI.Dtos.Enums;

namespace WatchShop_UI.Dtos.IndicationTypes.Response
{
    public class IndicationTypeDto
    {
        public byte Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public IndicationTypeEnum Name { get; set; }
    }
}
