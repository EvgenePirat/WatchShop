using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchShop_Core.Models.Comments.Request;
using WatchShop_Core.ServiceContracts;
using WatchShop_UI.Dtos.Comments.Request;
using WatchShop_UI.Dtos.Comments.Response;
using WatchShop_UI.Utilities.GeneralResponse;

namespace WatchShop_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        private readonly ILogger<CommentController> _logger;

        public CommentController(ICommentService commentService, IMapper mapper, ILogger<CommentController> logger)
        {
            _commentService = commentService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ApiResponse>> CreateCommentAsync([FromBody] CreateCommentDto dto)
        {
            _logger.LogInformation("{controller}.{method} - Post, Create Comment, Task started", nameof(CommentController), nameof(CreateCommentAsync));

            var mappedComment = _mapper.Map<CreateCommentModel>(dto);

            var result = await _commentService.CreateCommentAsync(mappedComment);

            var mappedResult = _mapper.Map<CommentDto>(result);

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.Created,
                Result = mappedResult
            };

            _logger.LogInformation("{controller}.{method} - Post, Create Comment, Result - Ok, Task ended", nameof(CommentController), nameof(CreateCommentAsync));

            return Ok(response);
        }

        [HttpGet("all")]
        public async Task<ActionResult<ApiResponse>> GetCommentsAsync()
        {
            _logger.LogInformation("{controller}.{method} - Get, get all comments, Task started",
                nameof(CommentController), nameof(GetCommentsAsync));

            var result = await _commentService.GetAllCommentsAsync();

            var mappedResult = _mapper.Map<IEnumerable<CommentDto>>(result);

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Result = mappedResult
            };

            _logger.LogInformation("{controller}.{method} - Get, get all comments, Result - Ok, Task ended",
                nameof(CommentController), nameof(GetCommentsAsync));

            return Ok(response);
        }

        [HttpPut("{id:Guid}")]
        [Authorize]
        public async Task<ActionResult<ApiResponse>> UpdateCommentAsync(Guid id, [FromBody] UpdateCommentDto dto)
        {
            _logger.LogInformation("{controller}.{method} - Post, Update Comment, Task started",
                nameof(CommentController), nameof(UpdateCommentAsync));

            var mappedModel = _mapper.Map<UpdateCommentModel>(dto);

            var result = await _commentService.UpdateCommentAsync(id, mappedModel);

            var mappedResult = _mapper.Map<CommentDto>(result);

            ApiResponse response = new ApiResponse()
            {
                Result = mappedResult,
                StatusCode = System.Net.HttpStatusCode.OK
            };

            _logger.LogInformation("{controller}.{method} - Post, Update Comment, Result - Ok, Task ended",
                nameof(CommentController), nameof(UpdateCommentAsync));

            return Ok(response);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteCommentAsync(Guid id)
        {
            _logger.LogInformation("{controller}.{method} - Delete, delete comment, Task started",
                nameof(CommentController), nameof(DeleteCommentAsync));

            await _commentService.DeleteCommentAsync(id);

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Result = $"Comment {id} - was deleted"
            };

            _logger.LogInformation("{controller}.{method} - Delete, delete comment, Result - Ok, Task ended",
                nameof(CommentController), nameof(DeleteCommentAsync));

            return Ok(response);
        }


        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ApiResponse>> GetCommentByIdAsync(Guid id)
        {
            _logger.LogInformation("{controller}.{method} - Get, get comment by id, Task started",
                nameof(CommentController), nameof(GetCommentByIdAsync));

            var result = await _commentService.GetCommentByIdAsync(id);

            var mappedResult = _mapper.Map<CommentDto>(result);

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Result = mappedResult
            };

            _logger.LogInformation("{controller}.{method} - Get, get comment by id, Result - Ok, Task ended",
                nameof(CommentController), nameof(GetCommentByIdAsync));

            return Ok(response);
        }

        [HttpGet("watch/{nameModel}")]
        public async Task<ActionResult<ApiResponse>> GetCommentsByWatchNameModelAsync(string nameModel)
        {
            _logger.LogInformation("{controller}.{method} - Get, get comments for watch name model, Task started",
                nameof(CommentController), nameof(GetCommentsByWatchNameModelAsync));

            var result = await _commentService.GetCommentsByWatchNameModelAsync(nameModel);

            var mappedResult = _mapper.Map<IEnumerable<CommentDto>>(result);

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Result = mappedResult
            };

            _logger.LogInformation("{controller}.{method} - Get, get comments for watch name model, Result - Ok, Task ended",
                nameof(CommentController), nameof(GetCommentsByWatchNameModelAsync));

            return Ok(response);
        }

        [HttpGet("user/{username}")]
        public async Task<ActionResult<ApiResponse>> GetCommentsByUserNameAsync(string username)
        {
            _logger.LogInformation("{controller}.{method} - Get, get comments for user name, Task started",
                nameof(CommentController), nameof(GetCommentsByUserNameAsync));

            var result = await _commentService.GetCommentsByUserNameAsync(username);

            var mappedResult = _mapper.Map<IEnumerable<CommentDto>>(result);

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Result = mappedResult
            };

            _logger.LogInformation("{controller}.{method} - Get, get comments for user name, Result - Ok, Task ended",
                nameof(CommentController), nameof(GetCommentsByUserNameAsync));

            return Ok(response);
        }

    }
}
