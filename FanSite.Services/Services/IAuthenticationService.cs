using FanSite.Services.Entities;

namespace FanSite.Services.Services
{
    public interface IAuthenticationService
    {
        Task<string> Authenticate(UserCredentials userCredentials);
    }
}
