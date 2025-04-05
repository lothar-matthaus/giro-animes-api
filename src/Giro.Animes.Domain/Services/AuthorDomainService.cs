using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Pagination;
using Giro.Animes.Domain.Interfaces.Repositories;
using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Domain.Services.Base;

namespace Giro.Animes.Domain.Services
{
    public class AuthorDomainService : DomainServiceBase<IAuthorRepository, Author>, IAuthorDomainService
    {
        public AuthorDomainService(IAuthorRepository authorRepository) : base(authorRepository)
        {
        }

        public async Task<(IEnumerable<Author>, int)> GetAllAuthorsPagedAsync(IPagination param)
        {
            return await _repository.GetAllPagedAsync(param, CancellationToken.None);
        }

        public async Task<Author> GetAuthorByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id, CancellationToken.None);
        }
    }
}
