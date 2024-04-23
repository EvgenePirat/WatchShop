using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatchShop_Core.Models.Messages.Request;
using WatchShop_Core.ServiceContracts;
using WatchShop_UI.Dtos.Messages.Request;
using WatchShop_UI.Utilities.GeneralResponse;

namespace WatchShop_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;
        private readonly ILogger<MessageController> _logger;

        public MessageController(IMessageService messageService, IMapper mapper, ILogger<MessageController> logger)
        {
            _logger = logger;
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> PostMessageAsync([FromBody] PostMessageDto messageDto)
        {
            _logger.LogInformation("{controller}.{method} - Post, post message with problem from client, Task started",
                nameof(MessageController), nameof(PostMessageAsync));

            var model = _mapper.Map<PostMessageModel>(messageDto);

            var result = await _messageService.SentMessageTelegramAsync(model);

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Result = result
            };

            _logger.LogInformation("{controller}.{method} - Post, post message with problem from client, Result - Ok, Task ended",
                nameof(MessageController), nameof(PostMessageAsync));

            return Ok(response);
        }

    }
}
