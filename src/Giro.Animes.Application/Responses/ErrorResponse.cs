using Giro.Animes.Application.Responses.Base;
using System.Net;

namespace Giro.Animes.Application.Responses
{
    /// <summary>
    /// Representa uma resposta de erro para a API 
    /// </summary>
    public class ErrorResponse : ApiResponse
    {
        /// <summary>
        /// Construtor privado para evitar instâncias não válidas
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="httpStatusCode"></param>
        /// <param name="message"></param>
        private ErrorResponse(bool isSuccess, HttpStatusCode httpStatusCode, string message) : base(isSuccess, httpStatusCode, message)
        {
        }

        /// <summary>
        /// Cria uma instância de <see cref="ErrorResponse"/> com o status code de erro"/>
        /// </summary>
        /// <param name="httpStatusCode"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ErrorResponse Create(HttpStatusCode httpStatusCode, string message)
        {
            return new ErrorResponse(false, httpStatusCode, message);
        }
    }
}
