using System.Net;

namespace WatchShop_UI.Utilities.Middleware.ExceptionsHandlers
{
    public record ExceptionResponse(HttpStatusCode StatusCode, string Description);
}
