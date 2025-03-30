using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Infra.Interfaces.Configs
{
    public interface IMediaConfig
    {
        string Path(string name);
        string MaxSize(string name);
        string[] AllowedExtensions(string name);
        string DefaultMedia(string name);
    }
}
