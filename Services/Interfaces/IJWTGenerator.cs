using RestApi.Domain.Core;

namespace RestApi.Services.Interfaces
{
    public interface IJWTGenerator
    {
        string GenerateTokenForUser(User user);
    }
}
