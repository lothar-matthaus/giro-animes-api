﻿
using Giro.Animes.Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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

            catch (Exception ex)
            {
                switch (ex)
                {
                    case DbUpdateException:
                        await HandleExceptions(context, "Ocorreu um erro ao salvar as alterações no banco de dados.", HttpStatusCode.InternalServerError);
                        break;
                    case ArgumentException:
                        await HandleExceptions(context, ex.Message, HttpStatusCode.BadRequest);
                        break;
                    case NotImplementedException:
                        await HandleExceptions(context, "O recurso buscado é inexistente ou ainda não foi implementado.", HttpStatusCode.NotImplemented);
                        break;
                    default:
                        await HandleExceptions(context, "Ocorreu um erro na solicitação. Tente novamente mais tarde.", HttpStatusCode.InternalServerError);
                        break;
                }
            }
        }

        Task HandleExceptions(HttpContext context, string message, HttpStatusCode statusCode)
        {
            var errorResponse = ErrorResponse.Create(statusCode, message);

            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsJsonAsync(errorResponse);
        }
    }
}
