using AutoMapper;
using WatchShop_Core.Domain.RepositoryContracts;
using WatchShop_Core.Exceptions;
using WatchShop_Core.Models.StrapMaterials.Response;
using WatchShop_Core.Models.Watches.Response;
using WatchShop_Core.ServiceContracts;

namespace WatchShop_Core.Services
{
    public class WatchService : IWatchService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WatchService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<WatchCharactersModel> GetWatchCharactersAsync()
        {
            await using var transaction = await _unitOfWork.BeginTransactionDbContextAsync();
            WatchCharactersModel watchCharacters = new();

            try
            {
                watchCharacters.ClockFaceColors = await _unitOfWork.ClockFaceColorRepository.GetAllAsync();
                watchCharacters.Countries = await _unitOfWork.ICountryRepositoryBase.GetAllAsync();
                watchCharacters.FrameColors = await _unitOfWork.IFrameColorRepositoryBase.GetAllAsync();
                watchCharacters.FrameMaterials = await _unitOfWork.IFrameMaterialRepositoryBase.GetAllAsync();
                watchCharacters.GlassTypes = await _unitOfWork.IGlassTypeRepositoryBase.GetAllAsync();
                watchCharacters.IndicationKinds = await _unitOfWork.IIndicationKindRepositoryBase.GetAllAsync();
                watchCharacters.IndicationTypes = await _unitOfWork.IIndicationTypeRepositoryBase.GetAllAsync();
                watchCharacters.MechanismTypes = await _unitOfWork.IMechanismTypeRepositoryBase.GetAllAsync();
                watchCharacters.Styles = await _unitOfWork.IStyleRepositoryBase.GetAllAsync();
                watchCharacters.AdditionalCharacteristics = await _unitOfWork.IAdditionalCharacteristicsRepositoryBase.GetAllAsync();
                watchCharacters.StrapMaterials = _mapper.Map<IEnumerable<StrapMaterialModel>>(await _unitOfWork.IStrapMaterialRepositoryBase.GetAllAsync());
            }
            catch(Exception ex)
            {
                await transaction.RollbackAsync();
                throw new WatchArgumentException(ex.Message);
            }

            return watchCharacters;
        }
    }
}
