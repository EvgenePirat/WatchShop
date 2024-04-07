using WatchShop_Core.Models.Enums;

namespace WatchShop_Core.Models.IndicationKinds.Request
{
    public class IndicationKindModel
    {
        public byte Id { get; set; }

        public IndicationKindEnum Name { get; set; }
    }
}
