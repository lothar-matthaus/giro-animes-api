using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Application.Responses.Base;
using System.Net;

namespace Giro.Animes.Application.Responses
{
    public class DetailResponse<TDto> : ApiResponse where TDto : BaseDTO
    {
        /// <summary>
        /// The data to be returned in the response.
        /// </summary>
        public TDto Data { get; private set; }

        /// <summary>
        /// Sets the data to be returned in the response. 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="isSuccess"></param>
        /// <param name="httpStatusCode"></param>
        /// <param name="message"></param>
        private DetailResponse(TDto data, bool isSuccess, HttpStatusCode httpStatusCode, string message) : base(isSuccess, httpStatusCode, message)
        {
            Data = data;
        }

        /// <summary>
        /// Sets the data to be returned in the response. 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="isSuccess"></param>
        /// <param name="httpStatusCode"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static DetailResponse<TDto> Create(TDto data, bool isSuccess, HttpStatusCode httpStatusCode, string message)
            => new DetailResponse<TDto>(data, isSuccess, httpStatusCode, message);

        /// <summary>
        /// Creates a new instance of DetailResponse with the specified parameters.
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="httpStatusCode"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static DetailResponse<TDto> Create(bool isSuccess, HttpStatusCode httpStatusCode, string message)
            => new DetailResponse<TDto>(null, isSuccess, httpStatusCode, message);
    }
}
