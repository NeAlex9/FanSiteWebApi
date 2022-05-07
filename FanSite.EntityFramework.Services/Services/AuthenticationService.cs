using FanSite.Services.Entities;
using FanSite.Services.Services;

namespace FanSite.EntityFramework.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthenticationService(IUserService userService, ITokenService tokenService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }

        public async Task<string> Authenticate(UserCredentials userCredentials)
        {
            await _userService.ValidateCredentials(userCredentials);
            string securityToken = _tokenService.GetToken();

            return securityToken;
        }
    }
}
