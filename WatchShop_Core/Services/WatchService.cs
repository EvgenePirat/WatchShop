using AutoMapper;
using WatchShop_Core.Domain.RepositoryContracts;
using WatchShop_Core.Exceptions;
using WatchShop_Core.Models.AdditionalCharacteristics.Response;
using WatchShop_Core.Models.Brends.Response;
using WatchShop_Core.Models.ClockFaceColors.Response;
using WatchShop_Core.Models.Countries.Response;
using WatchShop_Core.Models.FrameColors.Response;
using WatchShop_Core.Models.FrameMaterials.Response;
using WatchShop_Core.Models.GlassTypes.Response;
using WatchShop_Core.Models.IndicationKinds.Response;
using WatchShop_Core.Models.IndicationTypes.Response;
using WatchShop_Core.Models.MechanismTypes.Response;
using WatchShop_Core.Models.StrapMaterials.Response;
using WatchShop_Core.Models.Styles.Response;
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
            WatchCharactersModel watchCharacters = new();

            try
            {
                watchCharacters.ClockFaceColors = _mapper.Map<IEnumerable<ClockFaceColorModel>>(await _unitOfWork.ClockFaceColorRepository.GetAllAsync());
                watchCharacters.Countries = _mapper.Map<IEnumerable<CountryModel>>(await _unitOfWork.ICountryRepositoryBase.GetAllAsync());
                watchCharacters.FrameColors =  _mapper.Map<IEnumerable<FrameColorModel>>(await _unitOfWork.IFrameColorRepositoryBase.GetAllAsync());
                watchCharacters.FrameMaterials = _mapper.Map<IEnumerable<FrameMaterialModel>>(await _unitOfWork.IFrameMaterialRepositoryBase.GetAllAsync());
                watchCharacters.GlassTypes = _mapper.Map<IEnumerable<GlassTypeModel>>(await _unitOfWork.IGlassTypeRepositoryBase.GetAllAsync());
                watchCharacters.IndicationKinds = _mapper.Map<IEnumerable<IndicationKindModel>>(await _unitOfWork.IIndicationKindRepositoryBase.GetAllAsync());
                watchCharacters.IndicationTypes = _mapper.Map<IEnumerable<IndicationTypeModel>>(await _unitOfWork.IIndicationTypeRepositoryBase.GetAllAsync());
                watchCharacters.MechanismTypes = _mapper.Map<IEnumerable<MechanismTypeModel>>(await _unitOfWork.IMechanismTypeRepositoryBase.GetAllAsync());
                watchCharacters.Styles = _mapper.Map<IEnumerable<StyleModel>>(await _unitOfWork.IStyleRepositoryBase.GetAllAsync());
                watchCharacters.AdditionalCharacteristics = _mapper.Map<IEnumerable<AdditionalCharacteristicModel>>(await _unitOfWork.IAdditionalCharacteristicsRepositoryBase.GetAllAsync());
                watchCharacters.StrapMaterials = _mapper.Map<IEnumerable<StrapMaterialModel>>(await _unitOfWork.IStrapMaterialRepositoryBase.GetAllAsync());
                watchCharacters.Brends = _mapper.Map<IEnumerable<BrendModel>>(await _unitOfWork.BrendRepository.GetAllAsync());
            }
            catch(Exception ex)
            {
                throw new WatchArgumentException(ex.Message);
            }

            return watchCharacters;
        }
    }
}
