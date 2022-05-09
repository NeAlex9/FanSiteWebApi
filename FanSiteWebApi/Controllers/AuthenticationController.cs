using System;
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
        private const string AuthCookieName = "jwt";
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

            Response.Cookies.Append(AuthCookieName, securityToken, new CookieOptions
            {
                Expires = DateTime.Now.AddDays(1),
                IsEssential = true,
                SameSite = SameSiteMode.None,
                Secure = true,
                HttpOnly = true,
            });

           return Ok();
        }

        [HttpPost("logOut")]
        public IActionResult LogOut()
        {
            Response.Cookies.Append(AuthCookieName, "", new CookieOptions
            {
                IsEssential = true,
                SameSite = SameSiteMode.None,
                Secure = true,
                Expires = DateTime.Now.AddDays(-1),
                HttpOnly = true,
            });

            return Ok();
        }

        [HttpPost("logIn")]
        public async Task<IActionResult> LogIn([FromBody] UserCredentials userCredentials)
        {
            try
            {
                await _userService.ValidateCredentialsAsync(userCredentials);
                string securityToken = _tokenService.GetToken();

                Response.Cookies.Append(AuthCookieName, securityToken, new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(1),
                    IsEssential = true,
                    SameSite = SameSiteMode.None,
                    Secure = true,
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
