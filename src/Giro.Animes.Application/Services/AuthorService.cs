using Giro.Animes.Application.Custom;
using Giro.Animes.Application.DTOs;
using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Application.Interfaces.Enumerations;
using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Application.Mappers;
using Giro.Animes.Application.Services.Base;
using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Pagination;
using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Infra.Interfaces;

namespace Giro.Animes.Application.Services
{
    public class AuthorService : ApplicationServiceBase<IAuthorDomainService>, IAuthorService
    {
        public AuthorService(IApplicationUser applicationUser, INotificationService notificationService, IAuthorDomainService domainService) :
            base(applicationUser, notificationService, domainService)
        {
        }

        public async Task<IPagedEnumerable<AuthorDTO>> GetAllAuthorsPagedAsync(IPagination param)
        {
            (IEnumerable<Author> authors, int count) = await _domainService.GetAllAuthorsPagedAsync(param);
            IPagedEnumerable<AuthorDTO> pagedEnumerable = new PagedEnumerable<AuthorDTO>(authors?.Map(), param.Page, param.RowsPerPage, count);

            return pagedEnumerable;
        }   

        public async Task<AuthorDTO> GetAuthorByIdAsync(long id)
        {
            Author author = await _domainService.GetAuthorByIdAsync(id);
            AuthorDTO authorDTO = author?.Map();

            return authorDTO;
        }
    }
}
