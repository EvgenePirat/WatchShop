using System.Text.Json.Serialization;
using WatchShop_UI.Dtos.Enums;

namespace WatchShop_UI.Dtos.OrderStatuses.Response
{
    public class OrderStatusDto
    {
        public byte Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OrderStatusEnum Name { get; set; }
    }
}
