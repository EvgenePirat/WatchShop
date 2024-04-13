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

            var brendExist = await _unitOfWork.IBrendRepository.FindByBrendNameAsync(model.Name);

            if (brendExist != null)
                throw new BrendArgumentException("Brend with name already exist");

            _unitOfWork.IBrendRepository.Add(mappedEntity);

            await _unitOfWork.SaveAsync();

            return _mapper.Map<BrendModel>(mappedEntity);
        }

        public async Task DeleteBrendAsync(int id)
        {
            var brendToDelete = await _unitOfWork.IBrendRepository.GetByIdAsync(id)
                                    ?? throw new BrendArgumentException("Brend with id not exist");

            _unitOfWork.IBrendRepository.Delete(brendToDelete);

            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<BrendAllModel>> GetAllBrendsAsync()
        {
            var brends = await _unitOfWork.IBrendRepository.GetAllAsync(b => b.Watches);
            return _mapper.Map<IEnumerable<BrendAllModel>>(brends);
        }

        public async Task<BrendModel?> GetBrendByIdAsync(int id)
        {
            var brend = await _unitOfWork.IBrendRepository.GetByIdAsync(id) ?? throw new BrendArgumentException("Brend by id not found");
            return _mapper.Map<BrendModel>(brend);
        }

        public async Task<BrendModel?> GetBrendByNameAsync(string name)
        {
            var brend = await _unitOfWork.IBrendRepository.FindByBrendNameAsync(name) ?? throw new BrendArgumentException("Brend by name not found");
            return _mapper.Map<BrendModel>(brend);
        }

        public async Task<BrendModel> UpdateBrendAsync(int id, UpdateBrendModel model)
        {
            var brendToUpdate = await _unitOfWork.IBrendRepository.GetByIdAsync(id)
                        ?? throw new BrendArgumentException("Brend with id not exist");

            brendToUpdate.Name = model.Name;
            brendToUpdate.Description = model.Description;

            _unitOfWork.IBrendRepository.Update(brendToUpdate);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<BrendModel>(brendToUpdate);
        }
    }
}
