﻿using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.DTOs;

namespace Giro.Animes.Infra.Interfaces.Services
{
    public interface ITokenService
    {
        Task<UserTokenDTO> GenerateUserToken(Account account, CancellationToken cancellationToken);
        Task<UserTokenDTO> GenerateGuestToken(CancellationToken cancellationToken);
        Task<(string, string, string)> GetMediaByMediaToken(string token, CancellationToken cancellationToken);
        string GenerateMediaToken(Media media);
    }
}
