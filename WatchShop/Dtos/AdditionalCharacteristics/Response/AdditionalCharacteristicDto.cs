using WatchShop_UI.Dtos.Enums;

namespace WatchShop_UI.Dtos.AdditionalCharacteristics.Response
{
    public class AdditionalCharacteristicDto
    {
        public int Id { get; set; }

        public AdditionalCharacteristicsEnum Name { get; set; }

        public string? Description { get; set; }
    }
}
