using WatchShop_Core.Models.Enums;

namespace WatchShop_Core.Models.AdditionalCharacteristics.Response
{
    public class AdditionalCharacteristicModel
    {
        public int Id { get; set; }

        public AdditionalCharacteristicsEnum Name { get; set; }

        public string? Description { get; set; }
    }
}
