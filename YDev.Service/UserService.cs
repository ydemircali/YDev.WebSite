using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YDev.Common.Models;
using YDev.Data;
using YDev.Service.Helper;

namespace YDev.Service
{
    public interface IUserService : IBaseService<User>
    {
        public  Task<User> FindUser(string email, string password);
    }


    public class UserService : IUserService
    {
        private IRepository<User> _userDataProvider;
        public UserService(IRepository<User> userProvider)
        {
            _userDataProvider = userProvider;
        }

        public Task Create(User dto)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindUser(string email, string password)
        {
            string encodedPassword = Crypto.MD5Hash(password);

            return await _userDataProvider
                .FindByCondition(f => f.Email == email && f.Password == encodedPassword)
                .Include(user => user.Role)
                .FirstOrDefaultAsync();

        }

        public Task<User> GetItemById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetItems()
        {
            throw new NotImplementedException();
        }

        public Task Update(User dto)
        {
            throw new NotImplementedException();
        }
    }
}
