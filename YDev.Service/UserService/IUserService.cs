using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YDev.Common.Models;

namespace YDev.Service.UserService
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(long id);
        Task InsertUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(long id);
    }
}
