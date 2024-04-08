using Microsoft.AspNetCore.Mvc;
using WatchShop_Core.ServiceContracts;
using WatchShop_UI.Utilities.GeneralResponse;

namespace WatchShop_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchController : ControllerBase
    {
        private readonly ILogger<BrendController> _logger;
        private readonly IWatchService _watchService;

        public WatchController(ILogger<BrendController> logger, IWatchService watchService)
        {
            _logger = logger;
            _watchService = watchService;
        }

        [HttpGet("characteristic")]
        public async Task<ActionResult<ApiResponse>> GetWatchCharacteristic()
        {
            _logger.LogInformation("{controller}.{method} - Get, get watch characteristic, Task started",
                nameof(WatchController), nameof(GetWatchCharacteristic));

            var result = await _watchService.GetWatchCharactersAsync();

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Result = result
            };

            _logger.LogInformation("{controller}.{method} - Get, get watch characteristic, Result - Ok, Task ended",
                nameof(WatchController), nameof(GetWatchCharacteristic));

            return Ok(response);
        }
    }
}
