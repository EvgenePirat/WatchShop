using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatchShop_UI.Dtos.Products.Response;
using WatchShop_UI.Utilities.GeneralResponse;

namespace WatchShop_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchController : ControllerBase
    {
        private readonly ILogger<BrendController> _logger;

        public WatchController(ILogger<BrendController> logger)
        {
            _logger = logger;
        }

        [HttpGet("characteristic")]
        public async Task<ActionResult<ApiResponse>> GetWatchCharacteristic()
        {
            _logger.LogInformation("{controller}.{method} - Get, get watch characteristic, Task started",
                nameof(WatchController), nameof(GetWatchCharacteristic));

            var result = new WatchCharacters();

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
