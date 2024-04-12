using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.Watches.Request;
using WatchShop_Core.ServiceContracts;
using WatchShop_UI.Dtos.Products.Response;
using WatchShop_UI.Dtos.Watches.Request;
using WatchShop_UI.Dtos.Watches.Response;
using WatchShop_UI.Utilities.GeneralResponse;

namespace WatchShop_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchController : ControllerBase
    {
        private readonly ILogger<BrendController> _logger;
        private readonly IWatchService _watchService;
        private readonly IMapper _mapper;

        public WatchController(ILogger<BrendController> logger, IWatchService watchService, IMapper mapper)
        {
            _logger = logger;
            _watchService = watchService;
            _mapper = mapper;
        }

        [HttpGet("characteristic")]
        public async Task<ActionResult<ApiResponse>> GetWatchCharacteristicAsync()
        {
            _logger.LogInformation("{controller}.{method} - Get, get watch characteristic, Task started",
                nameof(WatchController), nameof(GetWatchCharacteristicAsync));

            var result = await _watchService.GetWatchCharactersAsync();
            var mappedResult = _mapper.Map<WatchCharactersDto>(result);

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Result = mappedResult
            };

            _logger.LogInformation("{controller}.{method} - Get, get watch characteristic, Result - Ok, Task ended",
                nameof(WatchController), nameof(GetWatchCharacteristicAsync));

            return Ok(response);
        }

        [HttpGet("all")]
        public async Task<ActionResult<ApiResponse>> GetAllWatches()
        {
            _logger.LogInformation("{controller}.{method} - Get, get all watches, Task started",
                nameof(WatchController), nameof(GetAllWatches));

            var result = await _watchService.GetAllWatchesAsync();
            var mappedResult = _mapper.Map<IEnumerable<WatchDto>>(result);

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Result = mappedResult
            };

            _logger.LogInformation("{controller}.{method} - Get, get all watches, Result - Ok, Task ended",
                nameof(WatchController), nameof(GetAllWatches));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> CreateWatchAsync([FromForm]CreateWatchDto watchDto)
        {
            _logger.LogInformation("{controller}.{method} - POST, create new watch, Task started",
                nameof(WatchController), nameof(CreateWatchAsync));

            var model = _mapper.Map<CreateWatchModel>(watchDto);

            var result = await _watchService.CreateWatchAsync(model);

            var mappedResult = _mapper.Map<WatchDto>(result);

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Result = mappedResult
            };

            _logger.LogInformation("{controller}.{method} - POST, create new watch, Result - Ok, Task ended",
                nameof(WatchController), nameof(CreateWatchAsync));

            return Ok(response);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ApiResponse>> UpdateWatchAsync(int id, UpdateWatchDto updateWatch)
        {
            _logger.LogInformation("{controller}.{method} - PUT, update exist watch, Task started",
                nameof(WatchController), nameof(UpdateWatchAsync));

            var model = _mapper.Map<UpdateWatchModel>(updateWatch);

            var result = await _watchService.UpdateWatchAsync(id, model);

            var mappedResult = _mapper.Map<WatchDto>(result);

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Result = mappedResult
            };

            _logger.LogInformation("{controller}.{method} - PUT, update exist watch, Result - Ok, Task ended",
                nameof(WatchController), nameof(UpdateWatchAsync));

            return Ok(response);
        }

        [HttpGet("{nameModel}")]
        public async Task<ActionResult<ApiResponse>> GetWatchByNameModelAsync(string nameModel)
        {
            _logger.LogInformation("{controller}.{method} - GET, get watch by name model, Task started",
                nameof(WatchController), nameof(GetWatchByNameModelAsync));

            var result = await _watchService.GetByNameModelAsync(nameModel);

            var mappedResult = _mapper.Map<WatchDto>(result);

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Result = mappedResult
            };

            _logger.LogInformation("{controller}.{method} - Get, get watch by name model, Result - Ok, Task ended",
                nameof(WatchController), nameof(GetWatchByNameModelAsync));

            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ApiResponse>> DeleteWatchByIdAsync(int id)
        {
            _logger.LogInformation("{controller}.{method} - DELETE, delete watch by id, Task started",
                nameof(WatchController), nameof(DeleteWatchByIdAsync));

            await _watchService.DeleteWatchByIdAsync(id);

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Result = $"Watch by id = {id} was delete"
            };

            _logger.LogInformation("{controller}.{method} - DELETE, delete watch by id, Result - Ok, Task ended",
                nameof(WatchController), nameof(DeleteWatchByIdAsync));

            return Ok(response);
        }
    }
}
