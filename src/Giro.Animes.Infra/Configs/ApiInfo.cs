using Giro.Animes.Infra.Interfaces.Configs;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Giro.Animes.Infra.Configs
{
    public class ApiInfo : IApiInfo
    {
        public string Name { get; }
        public string Version { get; }
        public string Description { get; }
        public string Host { get; }

        public ApiInfo(IConfiguration configuration, Assembly assembly)
        {
            Name = assembly.GetCustomAttribute<AssemblyTitleAttribute>()?.Title ?? throw new ArgumentNullException(nameof(Name), "Nome da API não encontrado.");
            Version = assembly.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version ?? throw new ArgumentNullException(nameof(Version), "Versão da API não encontrada.");
            Description = assembly.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description ?? throw new ArgumentNullException(nameof(Description), "Descrição da API não encontrada.");
            Host = configuration["Host"] ?? throw new ArgumentNullException(nameof(Host), "Host da API não encontrado.");
        }
    }
}
