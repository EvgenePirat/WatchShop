using Microsoft.EntityFrameworkCore.Storage;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Domain.RepositoryContracts;
using WatchShop_Infrastructure.DbContext;

namespace WatchShop_Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        private IBrendRepository _brendRepository;
        public IBrendRepository BrendRepository => _brendRepository ??= new BrendRepository(_context);

        private IClockFaceColorRepository _clockFaceColorRepository;
        public IClockFaceColorRepository ClockFaceColorRepository => _clockFaceColorRepository ??= new ClockFaceColorRepository(_context);

        private IStrapRepository _strapRepository;
        public IStrapRepository IStrapRepository => _strapRepository ??= new StrapRepository(_context);

        private IRepositoryBase<Country> _countryRepositoryBase;
        public IRepositoryBase<Country> ICountryRepositoryBase => _countryRepositoryBase ??= new RepositoryBase<Country>(_context);

        private IRepositoryBase<FrameColor> _frameColorRepositoryBase;
        public IRepositoryBase<FrameColor> IFrameColorRepositoryBase => _frameColorRepositoryBase ??= new RepositoryBase<FrameColor>(_context);

        private IRepositoryBase<FrameMaterial> _frameMaterialRepositoryBase;
        public IRepositoryBase<FrameMaterial> IFrameMaterialRepositoryBase => _frameMaterialRepositoryBase ??= new RepositoryBase<FrameMaterial>(_context);

        private IRepositoryBase<GlassType> _glassTypeRepositoryBase;
        public IRepositoryBase<GlassType> IGlassTypeRepositoryBase => _glassTypeRepositoryBase ??= new RepositoryBase<GlassType>(_context);

        private IRepositoryBase<IndicationKind> _indicationKindRepositoryBase;
        public IRepositoryBase<IndicationKind> IIndicationKindRepositoryBase => _indicationKindRepositoryBase ??= new RepositoryBase<IndicationKind>(_context);

        private IRepositoryBase<IndicationType> _indicationTypeRepositoryBase;
        public IRepositoryBase<IndicationType> IIndicationTypeRepositoryBase => _indicationTypeRepositoryBase ??= new RepositoryBase<IndicationType>(_context);

        private IRepositoryBase<MechanismType> _mechanismTypeRepositoryBase;
        public IRepositoryBase<MechanismType> IMechanismTypeRepositoryBase => _mechanismTypeRepositoryBase ??= new RepositoryBase<MechanismType>(_context);

        private IRepositoryBase<Style> _styleRepositoryBase;
        public IRepositoryBase<Style> IStyleRepositoryBase => _styleRepositoryBase ??= new RepositoryBase<Style>(_context);

        private IRepositoryBase<AdditionalCharacteristics> _additionalCharacteristicsRepositoryBase;
        public IRepositoryBase<AdditionalCharacteristics> IAdditionalCharacteristicsRepositoryBase => _additionalCharacteristicsRepositoryBase ??= new RepositoryBase<AdditionalCharacteristics>(_context);

        private IRepositoryBase<StrapMaterial> _strapMaterialRepositoryBase;
        public IRepositoryBase<StrapMaterial> IStrapMaterialRepositoryBase => _strapMaterialRepositoryBase ??= new RepositoryBase<StrapMaterial>(_context);

        private IWatchRepository _watchRepository;
        public IWatchRepository WatchRepository => _watchRepository ??= new WatchRepository(_context);

        private IRepositoryBase<Strap> _strapRepositoryBase;
        public IRepositoryBase<Strap> IStrapRepositoryBase => _strapRepositoryBase ??= new RepositoryBase<Strap>(_context);

        private IRepositoryBase<Frame> _frameRepositoryBase;
        public IRepositoryBase<Frame> IFrameRepositoryBase => _frameRepositoryBase ??= new RepositoryBase<Frame>(_context);

        private IRepositoryBase<ClockFace> _clockFaceRepositoryBase;
        public IRepositoryBase<ClockFace> IClockFaceRepositoryBase => _clockFaceRepositoryBase ??= new RepositoryBase<ClockFace>(_context);

        private IRepositoryBase<Dimension> _dimensionRepositoryBase;
        public IRepositoryBase<Dimension> IDimensionRepositoryBase => _dimensionRepositoryBase ??= new RepositoryBase<Dimension>(_context);

        public async Task<IDbContextTransaction> BeginTransactionDbContextAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
