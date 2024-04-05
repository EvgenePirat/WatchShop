using AutoMapper;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Domain.RepositoryContracts;
using WatchShop_Core.Exceptions;
using WatchShop_Core.Models.Brends.Request;
using WatchShop_Core.Models.Brends.Response;
using WatchShop_Core.ServiceContracts;

namespace WatchShop_Core.Services
{
    public class BrendService : IBrendService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BrendService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BrendModel> CreateBrendAsync(CreateBrendModel model)
        {
            var mappedEntity = _mapper.Map<Brend>(model);

            var brendExist = await _unitOfWork.BrendRepository.FindByBrendNameAsync(model.Name);

            if (brendExist != null)
                throw new BrendArgumentException("Brend with name already exist");

            _unitOfWork.BrendRepository.Add(mappedEntity);

            await _unitOfWork.SaveAsync();

            return _mapper.Map<BrendModel>(mappedEntity);
        }

        public async Task DeleteBrendAsync(int id)
        {
            var brendToDelete = await _unitOfWork.BrendRepository.GetByIdAsync(id)
                                    ?? throw new BrendArgumentException("Brend with id not exist");

            _unitOfWork.BrendRepository.Delete(brendToDelete);

            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<BrendModel>> GetAllBrendsAsync()
        {
            var brends = await _unitOfWork.BrendRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BrendModel>>(brends);
        }

        public async Task<BrendModel?> GetBrendByIdAsync(int id)
        {
            var brend = await _unitOfWork.BrendRepository.GetByIdAsync(id) ?? throw new BrendArgumentException("Brend by id not found");
            return _mapper.Map<BrendModel>(brend);
        }

        public async Task<BrendModel?> GetBrendByNameAsync(string name)
        {
            var brend = await _unitOfWork.BrendRepository.FindByBrendNameAsync(name) ?? throw new BrendArgumentException("Brend by name not found");
            return _mapper.Map<BrendModel>(brend);
        }

        public async Task<BrendModel> UpdateBrendAsync(int id, UpdateBrendModel model)
        {
            var brendToUpdate = await _unitOfWork.BrendRepository.GetByIdAsync(id)
                        ?? throw new BrendArgumentException("Brend with id not exist");

            brendToUpdate.Name = model.Name;
            brendToUpdate.Description = model.Description;

            _unitOfWork.BrendRepository.Update(brendToUpdate);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<BrendModel>(brendToUpdate);
        }
    }
}
