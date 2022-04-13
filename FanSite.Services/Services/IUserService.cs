using DomainEntities;

namespace FanSite.Services.Services
{
    public interface IUserService
    {
        IAsyncEnumerable<User> GetUsers();
        Task<bool> UpdateUser(int id, User user);
        Task<bool> DeleteUser(int id);
        Task<User> CreateUser(User user);
        Task<User> GetUserById(int id);
    }
}
