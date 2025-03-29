using System.Net;

namespace Giro.Animes.Application.Responses.Base
{
    public abstract class ApiResponse(bool isSuccess, HttpStatusCode httpStatusCode, string message)
    {
        public bool IsSuccess { get; private set; } = isSuccess;
        public HttpStatusCode StatusCode { get; private set; } = httpStatusCode;
        public string Message { get; private set; } = message;
    }
}
