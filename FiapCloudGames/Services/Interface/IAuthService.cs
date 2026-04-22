namespace FiapCloudGames.Services.Interface
{
    public interface IAuthService
    {

        string GenerateToken(IConfiguration _configuration, string username, string role);

    }
}
