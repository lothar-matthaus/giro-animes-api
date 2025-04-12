using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Application.Responses.Base;
using Giro.Animes.Domain.Common.Filters;
using Giro.Animes.Domain.Interfaces.Pagination;
using System.Net;
using System.Text.Json.Serialization;

namespace Giro.Animes.Application.Responses
{
    public class ListPagedResponse<TDto> : ApiResponse where TDto : BaseSimpleDTO
    {
        public IEnumerable<TDto> List { get; private set; }

        public int Page { get; private set; }

        public int RowsPerPage { get; private set; }

        public int TotalCount { get; set; }

        public int TotalPages { get; private set; }

        private ListPagedResponse(IEnumerable<TDto> list, bool isSuccess, HttpStatusCode httpStatusCode, string message, int page, int rowsPerPage, int totalCount) : base(isSuccess, httpStatusCode, message)
        {
            List = list;
            Page = page;
            RowsPerPage = rowsPerPage;
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling((double)TotalCount / RowsPerPage);
        }

        /// <summary>
        /// Creates a new instance of ListPagedResponse with the specified parameters. 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="pagination"></param>
        /// <param name="isSuccess"></param>
        /// <param name="httpStatusCode"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ListPagedResponse<TDto> Create(IEnumerable<TDto> list, bool isSuccess, HttpStatusCode httpStatusCode, string message, int page, int rowsPerPage, int totalCount)
            => new ListPagedResponse<TDto>(list, isSuccess, httpStatusCode, message, page, rowsPerPage, totalCount);

        /// <summary>
        /// Creates a new instance of ListPagedResponse with the specified parameters. 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ListPagedResponse<TDto> Create(HttpStatusCode statusCode, string message, int page, int rowsPerPage, int totalCount)
            => new ListPagedResponse<TDto>(null, true, statusCode, message, page, rowsPerPage, totalCount);
    }
}
