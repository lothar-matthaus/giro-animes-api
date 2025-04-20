using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Infra.Interfaces.Configs
{
    public interface ISmtpConfig
    {
        string Host { get; }
        int Port { get; }
        string UserName { get; }
        string Password { get; }
        bool EnableSsl { get; }
        string FromEmail { get; }
        string FromName { get; }
    }
}
