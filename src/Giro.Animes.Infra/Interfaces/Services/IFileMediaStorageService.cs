using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Infra.Interfaces.Services
{
    public interface IFileMediaStorageService
    {
        Task UploadAsync(Media media);
        Task UploadAsync(params Media[] media);
        Task<Stream> DownloadAsync(Media media);
        Task<bool> DeleteAsync(Media media);
        Task Rollback();
    }
}
