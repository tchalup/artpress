using System.Threading.Tasks;
using Artpress.Application.DTOs.Auth;

namespace Artpress.Application.Interfaces
{
    public interface IAuthService
    {
        Task<TokenResponse> LoginAsync(LoginRequest loginRequest);
        Task<TokenResponse> RefreshTokenAsync(string refreshToken);
    }
}
