using System.Text.Json.Serialization;
using WatchShop_UI.Dtos.Enums;

namespace WatchShop_UI.Dtos.Countries.Response
{
    public class CountryDto
    {
        public byte Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CountryEnum Name { get; set; }
    }
}
