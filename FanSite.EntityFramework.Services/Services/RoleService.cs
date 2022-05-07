using AutoMapper;
using FanSite.EntityFramework.Services.Context;
using FanSite.EntityFramework.Services.Entities;
using FanSite.Services.Entities;
using FanSite.Services.Services;
using Microsoft.EntityFrameworkCore;

namespace FanSite.EntityFramework.Services.Services
{
    public class RoleService : IRoleService
    {
        private readonly SiteContext _context;
        private readonly IMapper _mapper;

        public RoleService(SiteContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Role?> GetRoleByIdAsync(byte id)
        {
            var dto = await _context
                .Roles
                .AsNoTracking()
                .Where(role => role.Id == id)
                .FirstOrDefaultAsync();
            if (dto is null)
            {
                return null;
            }

            return _mapper.Map<Role>(dto);
        }

        public async Task<byte> CreateRoleAsync(Role role)
        {
            var dto = _mapper.Map<RoleDto>(role);
            await _context.Roles.AddAsync(dto);
            var result = await _context.SaveChangesAsync() > 0;
            if (!result)
            {
                throw new Exception("Cannot create role");
            }

            return dto.Id;
        }
    }
}
