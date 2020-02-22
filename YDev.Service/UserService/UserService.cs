using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YDev.Common.Models;
using YDev.Data.Repo;

namespace YDev.Service.UserService
{
    public class UserService : IUserService
    {
        private IAsyncRepository<User> userRepository;

        public UserService(IAsyncRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await userRepository.GetAll();
        }

        public async Task<User> GetUser(long id)
        {
            return await userRepository.Get(id);
        }

        public async Task InsertUser(User user)
        {
            await userRepository.Insert(user);
        }
        public async Task UpdateUser(User user)
        {
            await userRepository.Update(user);
        }

        public async Task DeleteUser(long id)
        {
            User user = await GetUser(id);
            await userRepository.Remove(user);
        }
    }
}
