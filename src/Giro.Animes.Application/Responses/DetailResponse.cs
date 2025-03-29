using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Application.Responses.Base;
using System.Net;

namespace Giro.Animes.Application.Responses
{
    public class DetailResponse<TDto> : ApiResponse where TDto : BaseDTO
    {
        public TDto Data { get; private set; }
        private DetailResponse(TDto data, bool isSuccess, HttpStatusCode httpStatusCode, string message) : base(isSuccess, httpStatusCode, message)
        {
            Data = data;
        }

        public static DetailResponse<TDto> Create(TDto data, bool isSuccess, HttpStatusCode httpStatusCode, string message)
            => new DetailResponse<TDto>(data, isSuccess, httpStatusCode, message);
    }
}
