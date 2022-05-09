namespace FanSite.Services.Services
{
    public interface ITokenService
    {
        string GetToken();
        bool ValidateToken(string jwt);
    }
}
