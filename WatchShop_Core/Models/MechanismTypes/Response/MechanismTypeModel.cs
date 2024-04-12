using WatchShop_Core.Models.Enums;

namespace WatchShop_Core.Models.MechanismTypes.Response
{
    public class MechanismTypeModel
    {
        public byte Id { get; set; }

        public MechanismTypeEnum Name { get; set; }

        public string? Description { get; set; }
    }
}
