using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatchShop_Core.ServiceContracts;
using WatchShop_Core.Services;
using WatchShop_UI.Dtos.Brends.Response;
using WatchShop_UI.Dtos.SalesStatistics.Response;
using WatchShop_UI.Utilities.GeneralResponse;

namespace WatchShop_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticController : ControllerBase
    {
        private readonly IAnalyticService _analyticService;
        private readonly IMapper _mapper;
        private readonly ILogger<AnalyticController> _logger;

        public AnalyticController(IAnalyticService analyticService, IMapper mapper, ILogger<AnalyticController> logger)
        {
            _analyticService = analyticService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetSalesStatisticsAsync()
        {
            _logger.LogInformation("{controller}.{method} - Get, get sales statistic, Task started",
                nameof(AnalyticController), nameof(GetSalesStatisticsAsync));

            var result = await _analyticService.CalculateSalesStatisticsAsync();

            var mappedResult = _mapper.Map<SalesStatisticDto>(result);

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Result = mappedResult
            };

            _logger.LogInformation("{controller}.{method} - Get, get sales statistic, Result - Ok, Task ended",
                nameof(AnalyticController), nameof(GetSalesStatisticsAsync));

            return Ok(response);
        }
    }
}
