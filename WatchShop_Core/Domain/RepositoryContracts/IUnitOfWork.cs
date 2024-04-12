using Microsoft.EntityFrameworkCore.Storage;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Domain.Entities.Identities;

namespace WatchShop_Core.Domain.RepositoryContracts
{
    public interface IUnitOfWork
    {
        IRepositoryBase<Country> CountryRepositoryBase { get; }
        IRepositoryBase<ApplicationUser> ApplicationUserRepositoryBase { get; }
        IRepositoryBase<ApplicationRole> ApplicationRoleRepositoryBase { get; }
        IRepositoryBase<Strap> StrapRepositoryBase { get; }
        IRepositoryBase<Frame> FrameRepositoryBase { get; }
        IRepositoryBase<ClockFace> ClockFaceRepositoryBase { get; }
        IRepositoryBase<Dimension> DimensionRepositoryBase { get; }
        IRepositoryBase<FrameColor> FrameColorRepositoryBase { get; }
        IRepositoryBase<FrameMaterial> FrameMaterialRepositoryBase { get; }
        IRepositoryBase<GlassType> GlassTypeRepositoryBase { get; }
        IRepositoryBase<IndicationKind> IndicationKindRepositoryBase { get; }
        IRepositoryBase<IndicationType> IndicationTypeRepositoryBase { get; }
        IRepositoryBase<MechanismType> MechanismTypeRepositoryBase { get; }
        IRepositoryBase<Style> StyleRepositoryBase { get; }
        IRepositoryBase<AdditionalCharacteristics> AdditionalCharacteristicsRepositoryBase { get; }
        IRepositoryBase<StrapMaterial> StrapMaterialRepositoryBase { get; }
        IRepositoryBase<OrderStatus> OrderStatusRepositoryBase { get; }

        IBrendRepository IBrendRepository { get; }
        IWatchRepository WatchRepository { get; }
        IOrderRepository OrderRepository { get; }
        IClockFaceColorRepository ClockFaceColorRepository { get; }
        Task SaveAsync();
        Task<IDbContextTransaction> BeginTransactionDbContextAsync();
    }
}
