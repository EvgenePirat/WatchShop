using Microsoft.EntityFrameworkCore;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Domain.RepositoryContracts;
using WatchShop_Infrastructure.DbContext;
using WatchShop_Infrastructure.Utilities;

namespace WatchShop_Infrastructure.Repositories
{
    public class WatchRepository : RepositoryBase<Watch>, IWatchRepository
    {
        public WatchRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Watch?> FindByNameModelAsync(string nameModel)
        {
            return await _context.Watches
                .IncludeMultiple(w => w.WatchAdditionalCharacteristics, 
                w => w.Brend, 
                w => w.ClockFace, 
                w => w.ClockFace.ClockFaceColor, 
                w => w.ClockFace.IndicationKind, 
                w => w.ClockFace.IndicationType, 
                w => w.Country, 
                w => w.Frame, 
                w => w.Frame.Dimensions, 
                w => w.Frame.FrameMaterial, 
                w => w.Frame.FrameColor, 
                w => w.GlassType, 
                w => w.MechanismType, 
                w => w.Strap, 
                w => w.Style, 
                w => w.Strap.StrapMaterial)
                .FirstOrDefaultAsync(b => b.NameModel.ToLower() == nameModel.ToLower());
        }

        public async Task<Watch?> GetByIdAsync(int id)
        {
            return await _context.Watches
                .IncludeMultiple(w => w.WatchAdditionalCharacteristics,
                w => w.Brend,
                w => w.ClockFace,
                w => w.ClockFace.ClockFaceColor,
                w => w.ClockFace.IndicationKind,
                w => w.ClockFace.IndicationType,
                w => w.Country,
                w => w.Frame,
                w => w.Frame.Dimensions,
                w => w.Frame.FrameMaterial,
                w => w.Frame.FrameColor,
                w => w.GlassType,
                w => w.MechanismType,
                w => w.Strap,
                w => w.Style,
                w => w.Strap.StrapMaterial)
                .FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
