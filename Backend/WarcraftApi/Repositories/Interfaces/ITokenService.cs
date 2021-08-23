using WarcraftApi.Data;

namespace WarcraftApi.Repositories.Interfaces
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, PlayerDTO user);
        bool IsTokenValid(string key, string issuer, string token);

    }
}