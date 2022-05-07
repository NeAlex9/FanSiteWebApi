using FanSite.Services.Entities;

namespace FanSite.Services.Services
{
    public interface IRoleService
    {
        Task<Role?> GetRoleByIdAsync(byte id);

        Task<byte> CreateRoleAsync(Role role);
    }
}
