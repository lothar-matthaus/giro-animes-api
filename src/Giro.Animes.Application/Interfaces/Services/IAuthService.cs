using Giro.Animes.Application.DTOs;
using Giro.Animes.Application.Interfaces.Services.Base;
using Giro.Animes.Application.Requests.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.Interfaces.Services
{
    public interface IAuthService : IApplicationServiceBase
    {
        Task<AuthDTO> Auth(AuthRequest request);
    }
}
