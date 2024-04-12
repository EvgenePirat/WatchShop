using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WatchShop_Core.Models.Auth.Request;
using WatchShop_Core.ServiceContracts;
using WatchShop_UI.Dtos.Auth.Request;
using WatchShop_UI.Dtos.Auth.Response;
using WatchShop_UI.Utilities.GeneralResponse;

namespace WatchShop_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly ILogger<AuthenticateController> _logger;
        private readonly IMapper _mapper;

        public AuthenticateController(IMapper mapper, IAuthenticateService authenticateService, ILogger<AuthenticateController> logger)
        {
            _authenticateService = authenticateService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse>> RegisterAsync([FromBody] RegisterDto dto)
        {
            _logger.LogInformation("{controller}.{method} - Post, register a new user, Task started",
                nameof(AuthenticateController), nameof(RegisterAsync));

            var mappedUser = _mapper.Map<RegisterModel>(dto);

            var result = await _authenticateService.RegisterAsync(mappedUser);

            var mappedResult = _mapper.Map<RegisterResponseDto>(result);

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Result = mappedResult
            };

            _logger.LogInformation("{controller}.{method} - Post, register a new user, Result - Ok, Task ended",
                nameof(AuthenticateController), nameof(RegisterAsync));

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse>> LoginAsync([FromBody] LoginDto loginDto)
        {
            _logger.LogInformation("{controller}.{method} - Post, login in system, Task started",
                nameof(AuthenticateController), nameof(LoginAsync));

            var model = _mapper.Map<LoginModel>(loginDto);

            var result = await _authenticateService.LoginAsync(model);

            var mappedResult = _mapper.Map<AuthResponseDto>(result);

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Result = mappedResult
            };

            _logger.LogInformation("{controller}.{method} - Post, login in system, Result - Ok, Task ended",
                nameof(AuthenticateController), nameof(RegisterAsync));

            return Ok(response);
        }
    }
}
