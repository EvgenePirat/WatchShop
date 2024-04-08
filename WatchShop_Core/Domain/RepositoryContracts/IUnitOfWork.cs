using Microsoft.EntityFrameworkCore.Storage;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.AdditionalCharacteristics.Response;
using WatchShop_Core.Models.IndicationKinds.Response;
using WatchShop_Core.Models.IndicationTypes.Response;
using WatchShop_Core.Models.MechanismTypes.Response;
using WatchShop_Core.Models.Styles.Response;

namespace WatchShop_Core.Domain.RepositoryContracts
{
    public interface IUnitOfWork
    {
        IRepositoryBase<Country> ICountryRepositoryBase { get; }
        IRepositoryBase<FrameColor> IFrameColorRepositoryBase { get; }
        IRepositoryBase<FrameMaterial> IFrameMaterialRepositoryBase { get; }
        IRepositoryBase<GlassType> IGlassTypeRepositoryBase { get; }
        IRepositoryBase<IndicationKind> IIndicationKindRepositoryBase { get; }
        IRepositoryBase<IndicationType> IIndicationTypeRepositoryBase { get; }
        IRepositoryBase<MechanismType> IMechanismTypeRepositoryBase { get; }
        IRepositoryBase<Style> IStyleRepositoryBase { get; }
        IRepositoryBase<AdditionalCharacteristics> IAdditionalCharacteristicsRepositoryBase { get; }
        IRepositoryBase<StrapMaterial> IStrapMaterialRepositoryBase { get; }

        IBrendRepository BrendRepository { get; }
        IClockFaceColorRepository ClockFaceColorRepository { get; }
        Task SaveAsync();
        Task<IDbContextTransaction> BeginTransactionDbContextAsync();
    }
}
