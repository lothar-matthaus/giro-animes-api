using Giro.Animes.Infra.Interfaces.Configs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Infra.Configs
{
    internal class ApiInfo : IApiInfo
    {
        public string Name { get; }
        public string Version { get; }
        public string Description { get; }

        public ApiInfo(IConfiguration configuration)
        {
            IConfigurationSection apiInfo = configuration.GetSection("ApiInfo");

            if (apiInfo == null)
                throw new ArgumentNullException(nameof(apiInfo), "Configuração de ApiInfo não encontrada.");

            Name = apiInfo["Name"] ?? throw new ArgumentNullException(nameof(Name), "Nome da API não encontrado.");
            Version = apiInfo["Version"] ?? throw new ArgumentNullException(nameof(Version), "Versão da API não encontrada.");
            Description = apiInfo["Description"] ?? throw new ArgumentNullException(nameof(Description), "Descrição da API não encontrada.");
        } 
    }
}
