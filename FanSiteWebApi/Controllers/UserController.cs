using FanSite.Services.Entities;
using FanSite.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace FanSiteWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet("ByEmail")]
        public async Task<ActionResult<User>> GetUserByEmail([FromQuery]string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById([FromRoute]int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody]User user)
        {
            var userId = await _userService.CreateUserAsync(user);
            user.Id = userId;
            return CreatedAtAction(nameof(GetUserById), new
            {
                id = user.Id
            }, user);
        }
    }
}
