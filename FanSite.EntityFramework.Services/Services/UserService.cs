using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainEntities;
using FanSite.Services.Services;

namespace FanSite.EntityFramework.Services.Services
{
    public class UserService : IUserService
    {
        public IAsyncEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUser(int id, User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
