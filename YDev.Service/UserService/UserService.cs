using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YDev.Common.Models;
using YDev.Data.DataProvider;
using YDev.Service.Helper;

namespace YDev.Service.UserService
{
    public class UserService : IUserService
    {
        private IUserDataProvider _userDataProvider;
        public UserService(IUserDataProvider userProvider)
        {
            _userDataProvider = userProvider;
        }

        public async Task<User> FindUser(string email, string password)
        {
            string encodedPassword = Crypto.MD5Hash(password);

            return await _userDataProvider.FindUser(f => f.Email == email && f.Password == encodedPassword);
        }

        public Task DeleteUser(long id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task InsertUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
