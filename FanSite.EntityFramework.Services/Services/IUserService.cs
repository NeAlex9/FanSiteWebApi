using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainEntities;

namespace FanSite.EntityFramework.Services.Services
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
