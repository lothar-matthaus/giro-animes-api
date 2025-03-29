using Giro.Animes.Application.Responses.Base;
using Giro.Animes.Domain.Interfaces.Pagination;
using System.Net;

namespace Giro.Animes.Application.Responses
{
    public class ListPagedResponse<TDto> : ApiResponse, IPagination where TDto : class
    {
        public IEnumerable<TDto> List { get; private set; }

        public int Page { get; set; }

        public int RowsPerPage { get; set; }

        public int Count { get; set; }

        public int TotalPages { get; private set; }

        private ListPagedResponse(IEnumerable<TDto> list, IPagination pagination, bool isSuccess, HttpStatusCode httpStatusCode, string message) : base(isSuccess, httpStatusCode, message)
        {
            List = list;
            Count = pagination.Count;
            TotalPages = (int)Math.Ceiling((double)Count / RowsPerPage);
            RowsPerPage = pagination.RowsPerPage;
            Page = pagination.Page;
        }

        public void SetCount(int count) => Count = count;

        public static ListPagedResponse<TDto> Create(IEnumerable<TDto> list, IPagination pagination, bool isSuccess, HttpStatusCode httpStatusCode, string message)
            => new ListPagedResponse<TDto>(list, pagination, isSuccess, httpStatusCode, message);

    }
}
