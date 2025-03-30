using Giro.Animes.Domain.Interfaces.Services.Base;

namespace Giro.Animes.Infra.Interfaces.Services
{
    public interface IFileStorageDomainService : IDomainServiceBase
    {
        Task<string> UploadAsync(byte[] file);
        Task<Stream> DownloadAsync(string filePath);
        Task<bool> DeleteAsync(string filePath);
    }
}
