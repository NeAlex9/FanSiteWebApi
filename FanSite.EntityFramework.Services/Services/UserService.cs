using AutoMapper;
using FanSite.EntityFramework.Services.Context;
using FanSite.EntityFramework.Services.Entities;
using FanSite.Services.Entities;
using FanSite.Services.Exceptions;
using FanSite.Services.Services;
using Microsoft.EntityFrameworkCore;

namespace FanSite.EntityFramework.Services.Services
{
    public class UserService : IUserService
    {
        private readonly SiteContext _context;
        private readonly IMapper _mapper;

        public UserService(SiteContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IAsyncEnumerable<User> GetUsersAsync(int offset, int limit) => _context
            .Users
            .Include(user => user.Role)
            .AsNoTracking()
            .Take(limit)
            .Skip(offset)
            .Select(dto => _mapper.Map<User>(dto))
            .ToAsyncEnumerable();

        public async Task<int> CreateUserAsync(User user)
        {
            ArgumentNullException.ThrowIfNull(nameof(user));
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = hashedPassword;
            var dto = _mapper.Map<UserDto>(user);

            var roleDto = await _context
                .Roles
                .FirstOrDefaultAsync(role => role.Id == user.Role.Id);
            if (roleDto is null)
            {
                return -1;
            }

            dto.Role = roleDto;
            await _context.Users.AddAsync(dto);
            var result = await _context.SaveChangesAsync() > 0;
            if (!result)
            {
                throw new Exception("Cannot create user");
            }

            return dto.Id;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            var dto = await _context
                .Users
                .Include(user => user.Role)
                .AsNoTracking()
                .Where(user => user.Id == id)
                .FirstOrDefaultAsync();
            if (dto is null)
            {
                return null;
            }

            return _mapper.Map<User>(dto);
        }

        public async Task<User?> GetUserByEmailAsync(string email) =>
            await _context.Users
                .AsNoTracking()
                .Where(user => user.Email == email)
                .Select(dto => _mapper.Map<User>(dto))
                .FirstOrDefaultAsync();
        
        public async Task ValidateCredentialsAsync(UserCredentials userCredentials)
        {
            var user = await _context.Users
                .AsNoTracking()
                .Where(user => user.Email == userCredentials.Email)
                .Select(userDto => _mapper.Map<User>(userDto))
                .FirstOrDefaultAsync();

            if (user is null || !AreValidCredentials(userCredentials, user))
            {
                throw new InvalidCredentialsException("Invalid email or password");
            }
        }

        private bool AreValidCredentials(UserCredentials userCredentials, User user)
        {
            return user.Email == userCredentials.Email
                   && BCrypt.Net.BCrypt.Verify(userCredentials.Password, user.Password);
        }
    }
}
