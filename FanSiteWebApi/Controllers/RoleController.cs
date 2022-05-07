using FanSite.Services.Entities;
using FanSite.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace FanSiteWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService ?? throw new ArgumentNullException(nameof(roleService));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRoleById([FromRoute]byte id)
        {
            var user = await _roleService.GetRoleByIdAsync(id);
            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<Role>> CreateRole([FromBody] Role role)
        {
            var roleId = await _roleService.CreateRoleAsync(role);
            role.Id = roleId;
            return CreatedAtAction(nameof(GetRoleById), new
            {
                id = role.Id
            }, role);
        }
    }
}