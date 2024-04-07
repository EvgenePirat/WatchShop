using WatchShop_Core.Models.Brends.Response;
using WatchShop_Core.Models.Countries.Response;
using WatchShop_Core.Models.GlassTypes.Response;
using WatchShop_Core.Models.MechanismTypes.Response;
using WatchShop_Core.Models.Straps.Response;
using WatchShop_Core.Models.Styles.Response;
using WatchShop_UI.Dtos.Brends.Response;
using WatchShop_UI.Dtos.Countries.Response;
using WatchShop_UI.Dtos.Enums;
using WatchShop_UI.Dtos.GlassTypes.Response;
using WatchShop_UI.Dtos.MechanismTypes.Response;
using WatchShop_UI.Dtos.Straps.Response;
using WatchShop_UI.Dtos.Styles.Response;

namespace WatchShop_UI.Dtos.Watches.Response
{
    public class WatchDto
    {
        public int Id { get; set; }
        public string NameModel { get; set; }

        public Gender Gender { get; set; }

        public GuaranteeMonth Guarantee { get; set; }

        public double Price { get; set; }

        public string? Description { get; set; }

        public TimeFormat TimeFormat { get; set; }

        public BrendDto Brend { get; set; }

        public StyleDto Style { get; set; }

        public StrapDto Strap { get; set; }

        public CountryDto Country { get; set; }

        public MechanismTypeDto MechanismType { get; set; }

        public GlassTypeDto GlassType { get; set; }
    }
}
