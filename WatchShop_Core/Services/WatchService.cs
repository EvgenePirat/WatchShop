using AutoMapper;
using WatchShop_Core.Domain.Entities;
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
using WatchShop_Core.Models.Watches.Request;
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

        public async Task<WatchModel> CreateWatchAsync(CreateWatchModel createWatch)
        {
            var transaction = await _unitOfWork.BeginTransactionDbContextAsync();

            try
            {
                var watch = _mapper.Map<Watch>(createWatch);

                Watch? checkWatch = await _unitOfWork.WatchRepository.FindByNameModelAsync(createWatch.NameModel);

                if (checkWatch != null)
                {
                    throw new WatchArgumentException("Watch with model name already exist");
                }

                _unitOfWork.WatchRepository.Add(watch);

                await _unitOfWork.SaveAsync();

                transaction.Commit();

                return _mapper.Map<WatchModel>(watch);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new WatchArgumentException(ex.Message);
            }
        }

        public async Task DeleteWatchByIdAsync(int watchId)
        {
            Watch watchFromDb = await _unitOfWork.WatchRepository.GetByIdAsync(watchId) ?? throw new WatchArgumentException("Watch by id not found for delete");
            _unitOfWork.WatchRepository.Delete(watchFromDb);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<WatchModel>> GetAllWatchesAsync()
        {
            var watches = await _unitOfWork.WatchRepository.GetAllAsync(
                w => w.WatchAdditionalCharacteristics, 
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
                w => w.Strap.StrapMaterial);
            return _mapper.Map<IEnumerable<WatchModel>>(watches);
        }

        public async Task<WatchModel> GetByNameModelAsync(string nameModel)
        {
            var watch = await _unitOfWork.WatchRepository.FindByNameModelAsync(nameModel) ?? throw new WatchArgumentException("watch by name model not found");
            return _mapper.Map<WatchModel>(watch);
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

        public async Task<WatchModel> UpdateWatchAsync(int watchId, UpdateWatchModel updateWatch)
        {
            Watch watchFromDb = await _unitOfWork.WatchRepository.GetByIdAsync(watchId) ?? throw new WatchArgumentException("watch by id not found");

            watchFromDb = SetDataForUpdate(watchFromDb, _mapper.Map<Watch>(updateWatch));

            _unitOfWork.WatchRepository.Update(watchFromDb);

            await _unitOfWork.SaveAsync();

            return _mapper.Map<WatchModel>(await _unitOfWork.WatchRepository.GetByIdAsync(watchId));     
        }

        private Watch SetDataForUpdate(Watch watchToUpdate, Watch watchWithNewData)
        {
            watchToUpdate.BrendId = watchWithNewData.BrendId;
            watchToUpdate.ClockFace.IndicationKindId = watchWithNewData.ClockFace.IndicationKindId;
            watchToUpdate.ClockFace.IndicationTypeId = watchWithNewData.ClockFace.IndicationTypeId;
            watchToUpdate.ClockFace.ClockFaceColorId = watchWithNewData.ClockFace.ClockFaceColorId;
            watchToUpdate.CountryId = watchWithNewData.CountryId;
            watchToUpdate.Description = watchWithNewData.Description;
            watchToUpdate.Frame.CaseShape = watchWithNewData.Frame.CaseShape;
            watchToUpdate.Frame.FrameColorId = watchWithNewData.Frame.FrameColorId;
            watchToUpdate.Frame.FrameMaterialId = watchWithNewData.Frame.FrameMaterialId;
            watchToUpdate.Frame.WaterResistance = watchWithNewData.Frame.WaterResistance;
            watchToUpdate.Frame.Dimensions.Length = watchWithNewData.Frame.Dimensions.Length;
            watchToUpdate.Frame.Dimensions.Thickness = watchWithNewData.Frame.Dimensions.Thickness;
            watchToUpdate.Frame.Dimensions.Weight = watchWithNewData.Frame.Dimensions.Weight;
            watchToUpdate.Frame.Dimensions.Width = watchWithNewData.Frame.Dimensions.Width;
            watchToUpdate.Frame.Dimensions.CaseDiameter = watchWithNewData.Frame.Dimensions.CaseDiameter;
            watchToUpdate.Gender = watchWithNewData.Gender;
            watchToUpdate.GlassTypeId = watchWithNewData.GlassTypeId;
            watchToUpdate.Guarantee = watchWithNewData.Guarantee;
            watchToUpdate.MechanismTypeId = watchWithNewData.MechanismTypeId;
            watchToUpdate.NameModel = watchWithNewData.NameModel;
            watchToUpdate.Price = watchWithNewData.Price;
            watchToUpdate.Strap.Name = watchWithNewData.Strap.Name;
            watchToUpdate.Strap.StrapMaterialId = watchWithNewData.Strap.StrapMaterialId;
            watchToUpdate.StyleId = watchWithNewData.StyleId;
            watchToUpdate.TimeFormat = watchWithNewData.TimeFormat;
            
            return watchToUpdate;
        }
    }
}
