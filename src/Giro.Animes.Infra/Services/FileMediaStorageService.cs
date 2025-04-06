using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Interfaces.Configs;
using Giro.Animes.Infra.Interfaces.Services;

namespace Giro.Animes.Infra.Services
{
    public class FileMediaStorageService : IFileMediaStorageService
    {
        private readonly IMediaConfig _mediaConfig;
        private IList<Media> _medias = new List<Media>();

        public FileMediaStorageService(IMediaConfig mediaConfig)
        {
            _mediaConfig = mediaConfig;
        }

        public Task<bool> DeleteAsync(Media media)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> DownloadAsync(Media media)
        {
            throw new NotImplementedException();
        }

        public Task Rollback()
        {
            FileStream fileStream = null;
            try
            {
                foreach (Media media in _medias)
                {
                    if (File.Exists(media.Url))
                    {
                        File.Delete(media.Url);
                    }
                }

                return Task.CompletedTask;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task UploadAsync(params Media[] param)
        {
            FileStream? fileStream = null;
            try
            {
                foreach (Media media in param)
                {
                    EnsureDirectory(media);

                    string basePath = _mediaConfig.Path(media.GetType().Name);
                    string fileName = $"{media.FileName}.{media.Extension}";
                    string fullPath = Path.Combine(basePath, fileName);

                    fileStream = new FileStream(fullPath, FileMode.Create);
                    fileStream.Write(media.File, 0, media.File.Length);
                    media.SetUrl(fullPath);
                    fileStream.Close();

                    _medias.Add(media);
                }

                return Task.CompletedTask;
            }
            catch (Exception)
            {
                fileStream?.Close();
                throw;
            }
        }

        public Task UploadAsync(Media media)
        {
            FileStream? fileStream = null;
            try
            {
                EnsureDirectory(media);

                string basePath = _mediaConfig.Path(media.GetType().Name);
                string fileName = $"{media.FileName}.{media.Extension.Split("/")[1]}";
                string fullPath = Path.Combine(basePath, fileName);

                fileStream = new FileStream(fullPath, FileMode.Create);
                fileStream.Write(media.File, 0, media.File.Length);
                media.SetUrl(fullPath);
                fileStream.Close();

                _medias.Add(media);

                return Task.CompletedTask;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void EnsureDirectory(Media media)
        {
            string dir = _mediaConfig.Path(media.GetType().Name);

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(_mediaConfig.Path(media.GetType().Name));
        }
    }
}
