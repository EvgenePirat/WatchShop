using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WatchShop_Core.Models.Users.Request;
using WatchShop_Core.ServiceContracts;
using WatchShop_UI.Dtos.Users.Request;
using WatchShop_UI.Dtos.Users.Response;
using WatchShop_UI.Utilities.GeneralResponse;

namespace WatchShop_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(IUserService userService, IMapper mapper, ILogger<UserController> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet("all")]
        public async Task<ActionResult<ApiResponse>> GetUsersAsync()
        {
            _logger.LogInformation("{controller}.{method} - Get, get all users, Task started",
                nameof(UserController), nameof(GetUsersAsync));

            var result = await _userService.GetAllUsersAsync();

            var mappedResult = _mapper.Map<IEnumerable<UserDto>>(result);

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Result = mappedResult
            };

            _logger.LogInformation("{controller}.{method} - Get, get all users, Result - Ok, Task ended",
                nameof(UserController), nameof(GetUsersAsync));

            return Ok(response);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<ApiResponse>> UpdateUserAsync(Guid id, [FromBody] UpdateUserDto dto)
        {
            _logger.LogInformation("{controller}.{method} - Post, Update User, Task started",
                nameof(UserController), nameof(UpdateUserAsync));

            var mappedModel = _mapper.Map<UpdateUserModel>(dto);

            var result = await _userService.UpdateUserAsync(id, mappedModel);

            var mappedResult = _mapper.Map<UserDto>(result);

            ApiResponse response = new ApiResponse()
            {
                Result = mappedResult,
                StatusCode = System.Net.HttpStatusCode.OK
            };

            _logger.LogInformation("{controller}.{method} - Post, Update User, Result - Ok, Task ended",
                nameof(UserController), nameof(UpdateUserAsync));

            return Ok(response);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteUserAsync(Guid id)
        {
            _logger.LogInformation("{controller}.{method} - Delete, delete user, Task started",
                nameof(UserController), nameof(DeleteUserAsync));

            await _userService.DeleteUserAsync(id);

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Result = $"Brend {id} - was deleted"
            };

            _logger.LogInformation("{controller}.{method} - Delete, delete user, Result - Ok, Task ended",
                nameof(UserController), nameof(DeleteUserAsync));

            return Ok(response);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ApiResponse>> GetUserByIdAsync(Guid id)
        {
            _logger.LogInformation("{controller}.{method} - Get, get user by id, Task started",
                nameof(UserController), nameof(GetUserByIdAsync));

            var result = await _userService.GetUserByIdAsync(id);

            var mappedResult = _mapper.Map<UserDto>(result);

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Result = mappedResult
            };

            _logger.LogInformation("{controller}.{method} - Get, get user by id, Result - Ok, Task ended",
                nameof(UserController), nameof(GetUserByIdAsync));

            return Ok(response);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<ApiResponse>> GetUserByUserNameAsync(string username)
        {
            _logger.LogInformation("{controller}.{method} - Get, get user by username, Task started",
                nameof(UserController), nameof(GetUserByUserNameAsync));

            var result = await _userService.GetUserByUserNameAsync(username);

            var mappedResult = _mapper.Map<UserDto>(result);

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Result = mappedResult
            };

            _logger.LogInformation("{controller}.{method} - Get, get user by username, Result - Ok, Task ended",
                nameof(UserController), nameof(GetUserByUserNameAsync));

            return Ok(response);
        }

    }
}
