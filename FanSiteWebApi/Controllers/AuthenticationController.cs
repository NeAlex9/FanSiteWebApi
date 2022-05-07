using FanSite.Services.Entities;
using FanSite.Services.Exceptions;
using FanSite.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace FanSiteWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private const string _authCookieName = "jwt";
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public AuthenticationController(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpPost("signUp")]
        public async Task<ActionResult<string>> SignUp([FromBody] User user)
        {
           var result =  await _userService.CreateUserAsync(user);
           if (result <= 0)
           {
               return NotFound();
           }

           var securityToken = _tokenService.GetToken();

            Response.Cookies.Append(_authCookieName, securityToken, new CookieOptions
            {
                HttpOnly = true,
            });

           return Ok();
        }

        [HttpPost("logOut")]
        public async Task<IActionResult> LogOut()
        {
            Response.Cookies.Delete(_authCookieName);
            return Ok();
        }

        [HttpPost("logIn")]
        public async Task<IActionResult> LogIn([FromBody] UserCredentials userCredentials)
        {
            try
            {
                await _userService.ValidateCredentials(userCredentials);
                string securityToken = _tokenService.GetToken();

                Response.Cookies.Append(_authCookieName, securityToken, new CookieOptions
                {
                    HttpOnly = true,
                });

                return Ok();
            }
            catch (InvalidCredentialsException)
            {
                return NotFound();
            }
        }
    }
}
