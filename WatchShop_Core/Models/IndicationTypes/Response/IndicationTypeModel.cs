using WatchShop_Core.Models.Enums;

namespace WatchShop_Core.Models.IndicationTypes.Response
{
    public class IndicationTypeModel
    {
        public byte Id { get; set; }

        public IndicationTypeEnum Name { get; set; }
    }
}
