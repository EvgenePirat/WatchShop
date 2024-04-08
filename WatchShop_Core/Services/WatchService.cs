using AutoMapper;
using WatchShop_Core.Domain.RepositoryContracts;
using WatchShop_Core.Exceptions;
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

            try
            {

            }
            catch(Exception ex)
            {
                await transaction.RollbackAsync();
                throw new WatchArgumentException(ex.Message);
            }
        }
    }
}
