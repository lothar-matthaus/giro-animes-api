using Giro.Animes.Application.DTOs;
using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Application.Interfaces.Enumerations;
using Giro.Animes.Application.Interfaces.Services.Base;
using Giro.Animes.Domain.Interfaces.Pagination;

namespace Giro.Animes.Application.Interfaces.Services
{
    public interface IAuthorService : IApplicationServiceBase
    {
        Task<AuthorDTO> GetAuthorByIdAsync(long id);
        Task<IPagedEnumerable<AuthorDTO>> GetAllAuthorsPagedAsync(IPagination param);
    }
}
