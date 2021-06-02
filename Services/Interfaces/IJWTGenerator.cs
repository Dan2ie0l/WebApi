using RestApi.Domain.Core;

namespace RestApi.Services.Interfaces
{
    public interface IJWTGenerator
    {
        string GenerateTokenForUser(string userId, string userName);
        string GenerateRefreshToken();
    }
}
