using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Infra.Interfaces.Configs
{
    public interface IApiInfo
    {
        string Name { get; }
        string Version { get; }
        string Description { get; }
    }
}
