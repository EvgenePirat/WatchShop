using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatchShop_Core.ServiceContracts;
using WatchShop_UI.Dtos.Payments.Response;
using WatchShop_UI.Utilities.GeneralResponse;

namespace WatchShop_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentService paymentService, IMapper mapper, ILogger<PaymentController> logger)
        {
            _logger = logger;
            _paymentService = paymentService;
            _mapper = mapper;
        }

        [HttpPost("{carttotal:double}")]
        public async Task<ActionResult<ApiResponse>> MakePayment(double carttotal)
        {
           _logger.LogInformation("{controller}.{method} - Post, create payment, Task started",
                nameof(PaymentController), nameof(MakePayment));

            var result = _paymentService.CreatePayment(carttotal);

            var mappedResult = _mapper.Map<PaymentIntentDto>(result);

            ApiResponse response = new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.Created,
                Result = mappedResult
            };

            _logger.LogInformation("{controller}.{method} - Post, create payment, Result - Ok, Task ended",
                nameof(PaymentController), nameof(MakePayment));

            return Ok(response);
        }
    }
}
