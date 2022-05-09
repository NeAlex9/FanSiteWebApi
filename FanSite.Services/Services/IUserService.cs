using FanSite.Services.Entities;

namespace FanSite.Services.Services
{
    public interface IUserService
    {
        Task<int> CreateUserAsync(User user);
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByEmailAsync(string email);
        Task ValidateCredentialsAsync(UserCredentials userCredentials);
    }
}
