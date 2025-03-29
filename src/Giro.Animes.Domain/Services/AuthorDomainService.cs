using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Pagination;
using Giro.Animes.Domain.Interfaces.Repositories.Read;
using Giro.Animes.Domain.Interfaces.Repositories.Write;
using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Domain.Services.Base;

namespace Giro.Animes.Domain.Services
{
    public class AuthorDomainService : DomainServiceBase<IAuthorWriteRepository, IAuthorReadRepository, Author>, IAuthorDomainService
    {
        public AuthorDomainService(IAuthorWriteRepository writeRepository, IAuthorReadRepository readRepository) : base(writeRepository, readRepository)
        {
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsPagedAsync(IPagination param)
        {
            return await _readRepository.GetAllPagedAsync(param, CancellationToken.None);
        }

        public async Task<Author> GetAuthorByIdAsync(long id)
        {
            Author author = await _readRepository.GetByIdAsync(id, CancellationToken.None);

            return author;
        }
    }
}
