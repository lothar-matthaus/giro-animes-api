
using Giro.Animes.Application.Responses;
using Microsoft.Data.SqlClient;
using System.Net;
using System.Net.Sockets;

namespace Giro.Animes.API.Middlewares
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
