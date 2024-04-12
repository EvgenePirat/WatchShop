using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchShop_Core.Models.Brends.Request;
using WatchShop_Core.ServiceContracts;
using WatchShop_UI.Dtos.Brends.Reequest;
using WatchShop_UI.Dtos.Brends.Response;
using WatchShop_UI.Dtos.Enums;
using WatchShop_UI.Utilities.GeneralResponse;

namespace WatchShop_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrendController : ControllerBase
    {
        private readonly IBrendService _brendService;
        private readonly IMapper _mapper;
        private readonly ILogger<BrendController> _logger;

        public BrendController(IBrendService brendService, IMapper mapper, ILogger<BrendController> logger)
        {
            _brendService = brendService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> CreateBrendAsync([FromBody] CreateBrendDto dto)
        {
            _logger.LogInformation("{controller}.{method} - Post, Create Brend, Task started", nameof(BrendController), nameof(CreateBrendAsync));

            var mappedBrend = _mapper.Map<CreateBrendModel>(dto);

            var result = await _brendService.CreateBrendAsync(mappedBrend);

            var mappedResult = _mapper.Map<BrendDto>(result);

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.Created,
                Result = mappedResult
            };

            _logger.LogInformation("{controller}.{method} - Post, Create Brend, Result - Ok, Task ended", nameof(BrendController), nameof(CreateBrendAsync));

            return Ok(response);
        }

        [HttpGet("all")]
        public async Task<ActionResult<ApiResponse>> GetBrendsAsync()
        {
            _logger.LogInformation("{controller}.{method} - Get, get all brends, Task started",
                nameof(BrendController), nameof(GetBrendsAsync));

            var result = await _brendService.GetAllBrendsAsync();

            var mappedResult = _mapper.Map<IEnumerable<BrendDto>>(result);

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Result = mappedResult
            };

            _logger.LogInformation("{controller}.{method} - Get, get all brends, Result - Ok, Task ended",
                nameof(BrendController), nameof(GetBrendsAsync));

            return Ok(response);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ApiResponse>> UpdateBrendAsync(int id, [FromBody] UpdateBrendDto dto)
        {
            _logger.LogInformation("{controller}.{method} - Post, Update Brend, Task started",
                nameof(BrendController), nameof(UpdateBrendAsync));

            var mappedModel = _mapper.Map<UpdateBrendModel>(dto);

            var result = await _brendService.UpdateBrendAsync(id, mappedModel);

            var mappedResult = _mapper.Map<BrendDto>(result);

            ApiResponse response = new ApiResponse()
            {
                Result = mappedResult,
                StatusCode = System.Net.HttpStatusCode.OK
            };

            _logger.LogInformation("{controller}.{method} - Post, Update Brend, Result - Ok, Task ended",
                nameof(BrendController), nameof(UpdateBrendAsync));

            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBrendAsync(int id)
        {
            _logger.LogInformation("{controller}.{method} - Delete, delete brend, Task started",
                nameof(BrendController), nameof(DeleteBrendAsync));

            await _brendService.DeleteBrendAsync(id);

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Result = $"Brend {id} - was deleted"
            };

            _logger.LogInformation("{controller}.{method} - Delete, delete brend, Result - Ok, Task ended",
                nameof(BrendController), nameof(DeleteBrendAsync));

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse>> GetBrendByIdAsync(int id)
        {
            _logger.LogInformation("{controller}.{method} - Get, get brend by id, Task started",
                nameof(BrendController), nameof(GetBrendByIdAsync));

            var result = await _brendService.GetBrendByIdAsync(id);

            var mappedResult = _mapper.Map<BrendDto>(result);

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Result = mappedResult
            };

            _logger.LogInformation("{controller}.{method} - Get, get brend by id, Result - Ok, Task ended",
                nameof(BrendController), nameof(GetBrendsAsync));

            return Ok(response);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<ApiResponse>> GetBrendByNameAsync(string name)
        {
            _logger.LogInformation("{controller}.{method} - Get, get brend by name, Task started",
                nameof(BrendController), nameof(GetBrendByNameAsync));

            var result = await _brendService.GetBrendByNameAsync(name);

            var mappedResult = _mapper.Map<BrendDto>(result);

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Result = mappedResult
            };

            _logger.LogInformation("{controller}.{method} - Get, get brend by name, Result - Ok, Task ended",
                nameof(BrendController), nameof(GetBrendsAsync));

            return Ok(response);
        }
    }
}
