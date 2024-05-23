using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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
        private readonly IBlobService _blobService;
        private const string Storage_Container_Name = "myrestorand";


        public WatchService(IBlobService blobService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _blobService = blobService;
        }

        public async Task<WatchModel> CreateWatchAsync(CreateWatchModel createWatch)
        {
            try
            {
                var watch = _mapper.Map<Watch>(createWatch);

                Watch? checkWatch = await _unitOfWork.WatchRepository.FindByNameModelAsync(createWatch.NameModel);

                if (checkWatch != null)
                    throw new WatchArgumentException("Watch with model name already exist");

                watch.Images = await SavePhotos(createWatch.Files, createWatch.NameModel);

                for(int i = 0; i < createWatch.WatchAdditionalCharacteristicsList.Count; i++)
                {
                    watch.WatchAdditionalCharacteristics.Add(new WatchAdditionalCharacteristic() { AdditionalCharacteristicsId = createWatch.WatchAdditionalCharacteristicsList[i] });
                }

                _unitOfWork.WatchRepository.Add(watch);

                await _unitOfWork.SaveAsync();

                return _mapper.Map<WatchModel>(await _unitOfWork.WatchRepository.GetByIdAsync(watch.Id));
            }
            catch (Exception ex)
            {
                throw new WatchArgumentException(ex.Message);
            }
        }


        private async Task<List<Image>> SavePhotos(IFormFile[] files, string nameModel)
        {
            List<Image> photos = new List<Image>();

            foreach (var file in files)
            {
                string fileName = $"{Guid.NewGuid()}{Path.GetExtension(nameModel)}";

                Image imageToSave = new()
                {
                    Path = await _blobService.UploadBlob(fileName, Storage_Container_Name, file),
                    UploadDateTime = DateTime.Now,
                };
                photos.Add(imageToSave);
            }

            return photos;
        }

        public async Task DeleteWatchByIdAsync(int watchId)
        {
            Watch watchFromDb = await _unitOfWork.WatchRepository.GetByIdAsync(watchId) ?? throw new WatchArgumentException("Watch by id not found for delete");
            _unitOfWork.StrapRepositoryBase.Delete(watchFromDb.Strap);
            _unitOfWork.DimensionRepositoryBase.Delete(watchFromDb.Frame.Dimensions);
            _unitOfWork.FrameRepositoryBase.Delete(watchFromDb.Frame);
            _unitOfWork.ClockFaceRepositoryBase.Delete(watchFromDb.ClockFace);
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
                w => w.Strap.StrapMaterial,
                w => w.Comments,
                w => w.Images);
            return _mapper.Map<IEnumerable<WatchModel>>(watches);
        }

        public async Task<WatchModel> GetByNameModelAsync(string nameModel)
        {
            var watch = await _unitOfWork.WatchRepository.FindByNameModelAsync(nameModel) ?? throw new WatchArgumentException("Watch by name model not found");
            return _mapper.Map<WatchModel>(watch);
        }

        public async Task<WatchCharactersModel> GetWatchCharactersAsync()
        {
            WatchCharactersModel watchCharacters = new();

            try
            {
                watchCharacters.ClockFaceColors = _mapper.Map<IEnumerable<ClockFaceColorModel>>(await _unitOfWork.ClockFaceColorRepository.GetAllAsync());
                watchCharacters.Countries = _mapper.Map<IEnumerable<CountryModel>>(await _unitOfWork.CountryRepositoryBase.GetAllAsync());
                watchCharacters.FrameColors =  _mapper.Map<IEnumerable<FrameColorModel>>(await _unitOfWork.FrameColorRepositoryBase.GetAllAsync());
                watchCharacters.FrameMaterials = _mapper.Map<IEnumerable<FrameMaterialModel>>(await _unitOfWork.FrameMaterialRepositoryBase.GetAllAsync());
                watchCharacters.GlassTypes = _mapper.Map<IEnumerable<GlassTypeModel>>(await _unitOfWork.GlassTypeRepositoryBase.GetAllAsync());
                watchCharacters.IndicationKinds = _mapper.Map<IEnumerable<IndicationKindModel>>(await _unitOfWork.IndicationKindRepositoryBase.GetAllAsync());
                watchCharacters.IndicationTypes = _mapper.Map<IEnumerable<IndicationTypeModel>>(await _unitOfWork.IndicationTypeRepositoryBase.GetAllAsync());
                watchCharacters.MechanismTypes = _mapper.Map<IEnumerable<MechanismTypeModel>>(await _unitOfWork.MechanismTypeRepositoryBase.GetAllAsync());
                watchCharacters.Styles = _mapper.Map<IEnumerable<StyleModel>>(await _unitOfWork.StyleRepositoryBase.GetAllAsync());
                watchCharacters.AdditionalCharacteristics = _mapper.Map<IEnumerable<AdditionalCharacteristicModel>>(await _unitOfWork.AdditionalCharacteristicsRepositoryBase.GetAllAsync());
                watchCharacters.StrapMaterials = _mapper.Map<IEnumerable<StrapMaterialModel>>(await _unitOfWork.StrapMaterialRepositoryBase.GetAllAsync());
                watchCharacters.Brends = _mapper.Map<IEnumerable<BrendModel>>(await _unitOfWork.IBrendRepository.GetAllAsync());
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
