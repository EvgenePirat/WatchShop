using WatchShop_Core.Models.Enums;

namespace WatchShop_Core.Models.AdditionalCharacteristics.Request
{
    public class CreateAdditionalCharacteristicModel
    {
        public AdditionalCharacteristicsEnum Name { get; set; }

        public string? Description { get; set; }
    }
}
