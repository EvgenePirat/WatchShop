using System.Net;
using WatchShop_Core.Exceptions;

namespace WatchShop_UI.Utilities.Middleware.ExceptionsHandlers
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, "An unexpected error occurred.");

            var response = exception switch
            {
                BrendArgumentException _ => new ExceptionResponse(HttpStatusCode.BadRequest, exception.Message),
                UserArgumentException _ => new ExceptionResponse(HttpStatusCode.BadRequest, exception.Message),
                WatchArgumentException _ => new ExceptionResponse(HttpStatusCode.BadRequest, exception.Message),
                ImageArgumentException _ => new ExceptionResponse(HttpStatusCode.BadRequest, exception.Message),
                OrderArgumentException _ => new ExceptionResponse(HttpStatusCode.BadRequest, exception.Message),
                AuthArgumentException _ => new ExceptionResponse(HttpStatusCode.BadRequest, exception.Message),
                ApplicationException _ => new ExceptionResponse(HttpStatusCode.BadRequest, "Application exception occurred."),
                KeyNotFoundException _ => new ExceptionResponse(HttpStatusCode.NotFound, "The request key not found."),
                UnauthorizedAccessException _ => new ExceptionResponse(HttpStatusCode.Unauthorized, "Unauthorized."),
                OperationCanceledException _ => new ExceptionResponse(HttpStatusCode.RequestTimeout, exception.Message),
                _ => new ExceptionResponse(HttpStatusCode.InternalServerError, "Internal server error. Please retry later.")
            }; ;

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)response.StatusCode;
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
