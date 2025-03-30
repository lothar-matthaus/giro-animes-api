
using Giro.Animes.Application.Responses;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Giro.Animes.Shared.Middleware
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public ExceptionHandlingMiddleware()
        {
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }

            catch (NotImplementedException)
            {
                await HandleExceptions(context, "O recurso buscado é inexistente ou ainda não foi implementado.", HttpStatusCode.NotImplemented);
            }

            catch (Exception)
            {
                await HandleExceptions(context, "Ocorreu um erro na solicitação. Tente novamente mais tarde.", HttpStatusCode.InternalServerError);
            }
        }

        public static Task HandleExceptions(HttpContext context, string message, HttpStatusCode statusCode)
        {
            var errorResponse = ErrorResponse.Create(statusCode, message);

            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsJsonAsync(errorResponse);
        }
    }
}
