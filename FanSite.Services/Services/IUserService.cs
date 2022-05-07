using FanSite.Services.Entities;

namespace FanSite.Services.Services
{
    public interface IUserService
    {
        IAsyncEnumerable<User> GetUsersAsync(int offset, int limit);
        Task<bool> UpdateUserAsync(int id, User user);
        Task<bool> DeleteUserAsync(int id);
        Task<int> CreateUserAsync(User user);
        Task<User?> GetUserByIdAsync(int id);
        Task ValidateCredentials(UserCredentials userCredentials);
    }
}
