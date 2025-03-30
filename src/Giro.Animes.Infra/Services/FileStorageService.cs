using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Infra.Interfaces.Configs;
using Giro.Animes.Infra.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Infra.Services
{
    public class FileStorageService : IFileStorageDomainService
    {
        private readonly IAppConfig _appConfig;

        public FileStorageService(IAppConfig appConfig)
        {
            _appConfig = appConfig;
        }
        public Task<bool> DeleteAsync(string filePath)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> DownloadAsync(string filePath)
        {
            throw new NotImplementedException();
        }

        public Task<string> UploadAsync(byte[] file)
        {
            throw new NotImplementedException();
        }
    }
}
