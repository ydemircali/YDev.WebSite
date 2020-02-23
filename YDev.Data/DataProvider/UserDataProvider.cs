using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YDev.Common.Models;

namespace YDev.Data.DataProvider
{
    public interface IUserDataProvider
    {
        User GetUser(long id);
        Task<List<User>> GetUsers();
        Task<List<User>> FindUsers(Expression<Func<User, bool>> predicate);
        Task<User> FindUser(Expression<Func<User, bool>> predicate);
        Task<long> CountUser();
    }
    public class UserDataProvider : IUserDataProvider
    {
        private readonly AppDBContext _context;

        public UserDataProvider(AppDBContext context)
        {
            _context = context;
        }

        public Task<long> CountUser()
        {
            throw new NotImplementedException();
        }

        public Task<User> FindUser(Expression<Func<User, bool>> predicate)
        {
            return _context.Users.Where(predicate).Include(user => user.Role).FirstOrDefaultAsync();
        }

        public Task<List<User>> FindUsers(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public User GetUser(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
