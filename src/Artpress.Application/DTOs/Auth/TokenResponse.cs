#nullable disable
namespace Artpress.Application.DTOs.Auth
{
    public class TokenResponse
    {
        public string AccessToken { get; set; }
        public DateTime ExpiresIn { get; set; }
        public string RefreshToken { get; set; }
    }
}
