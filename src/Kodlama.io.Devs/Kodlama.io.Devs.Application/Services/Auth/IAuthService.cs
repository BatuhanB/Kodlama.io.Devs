using Core.Security.Entities;
using Core.Security.JWT;

namespace Kodlama.io.Devs.Application.Services.Auth
{
    public interface IAuthService
    {
        Task<AccessToken> CreateAccessToken(User user);
        Task<RefreshToken> CreateRefreshToken(User user,string ipAdress);
        Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);
    }
}
