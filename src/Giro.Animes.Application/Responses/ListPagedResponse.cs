using Giro.Animes.Application.Responses.Base;
using Giro.Animes.Domain.Interfaces.Pagination;
using System.Net;

namespace Giro.Animes.Application.Responses
{
    public class ListPagedResponse<TDto> : ApiResponse, IPagination where TDto : class
    {
        public IEnumerable<TDto> List { get; private set; }

        public int Page { get; private set; }

        public int RowsPerPage { get; private set; }

        public int Count { get; private set; }

        public int TotalPages { get; private set; }

        private ListPagedResponse(IEnumerable<TDto> list, IPagination pagination, bool isSuccess, HttpStatusCode httpStatusCode, string message) : base(isSuccess, httpStatusCode, message)
        {
            List = list;
            Count = pagination.Count;
            Page = pagination.Page;
            RowsPerPage = pagination.RowsPerPage;
            TotalPages = (int)Math.Ceiling((double)Count / RowsPerPage);
        }

        /// <summary>
        /// Sets the list of items to be returned in the response.
        /// </summary>
        /// <param name="count"></param>
        public void SetCount(int count) => Count = count;

        /// <summary>
        /// Creates a new instance of ListPagedResponse with the specified parameters. 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="pagination"></param>
        /// <param name="isSuccess"></param>
        /// <param name="httpStatusCode"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ListPagedResponse<TDto> Create(IEnumerable<TDto> list, IPagination pagination, bool isSuccess, HttpStatusCode httpStatusCode, string message)
            => new ListPagedResponse<TDto>(list, pagination, isSuccess, httpStatusCode, message);

        /// <summary>
        /// Creates a new instance of ListPagedResponse with the specified parameters. 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ListPagedResponse<TDto> Create(IPagination pagination, HttpStatusCode statusCode, string message)
            => new ListPagedResponse<TDto>(null, pagination, true, statusCode, message);

        /// <summary>
        /// Sets the pagination information for the response. 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rowsPerPage"></param>
        /// <param name="count"></param>
        public void SetPagination(int page, int rowsPerPage, int count)
        {
            Page = page;
            RowsPerPage = rowsPerPage;
            Count = count;
        }
    }
}
