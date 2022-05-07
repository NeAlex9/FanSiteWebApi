using FanSite.EntityFramework.Services.Services;
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
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] UserCredentials userCredentials)
        {
            try
            {
                string token = await _authenticationService.Authenticate(userCredentials);
                return Ok(token);
            }
            catch (InvalidCredentialsException)
            {
                return NotFound();
            }
        }
    }
}
