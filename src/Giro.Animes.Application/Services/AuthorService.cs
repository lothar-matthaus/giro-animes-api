using Giro.Animes.Application.Custom;
using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Application.Interfaces.Enumerations;
using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Application.Mappers;
using Giro.Animes.Application.Services.Base;
using Giro.Animes.Domain.Common.Filters;
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

        public async Task<IEnumerable<SimpleComboxDTO>> GetAllAuthorsComboxAsync(CancellationToken cancellationToken)
        {
            IEnumerable<Author> authors = await _domainService.GetAllAuthorsAsync(cancellationToken);
            IEnumerable<SimpleComboxDTO> comboxDTOs = authors?.MapCombox();

            return comboxDTOs;
        }

        public async Task<IPagedEnumerable<DetailedAuthorDTO>> GetAllAuthorsPagedAsync(IPagination<AuthorFilter> param, CancellationToken cancellationToken)
        {
            (IEnumerable<Author> authors, int count) = await _domainService.GetAllAuthorsPagedAsync(param, cancellationToken);
            IPagedEnumerable<DetailedAuthorDTO> pagedEnumerable = PagedEnumerable<DetailedAuthorDTO>.Create(authors?.Map(), param.Page, param.RowsPerPage, count);

            return pagedEnumerable;
        }

        public async Task<DetailedAuthorDTO> GetAuthorByIdAsync(long id)
        {
            Author author = await _domainService.GetAuthorByIdAsync(id);
            DetailedAuthorDTO authorDTO = author?.Map();

            return authorDTO;
        }
    }
}
