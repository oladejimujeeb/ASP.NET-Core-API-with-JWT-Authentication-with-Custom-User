using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Entities.Identity;
using WebAPI.Interface.Repository;

namespace WebAPI.Implementation.Repositories
{
    public class UserRepository:IUser
    {
        private readonly ApplicationContext _Context;

        public UserRepository(ApplicationContext context)
        {
            _Context = context;
        }      
        public async Task<bool> ComfirmEmail(string username)
        {
            var checkUserName = await _Context.Users.AsQueryable().AnyAsync(x => x.Email.ToLower() == username.ToLower());
            return checkUserName;
        }

        public async Task<IList<User>> GetAllUsers()
        {
            var getAll = await _Context.Users.ToListAsync();
            return getAll;
        }

        public async Task<User> GetUser(string email)
        {
            var checkUserName = await _Context.Users.FirstOrDefaultAsync(x => x.Email==email);
            return checkUserName;
        }

        public async Task<User> ResgisterUser(User user)
        {
            var create = await _Context.AddAsync(user);
            await _Context.SaveChangesAsync();
            return user;
        }

        public User Update(User user)
        {
            var update = _Context.Update(user);
            _Context.SaveChanges();
            return user;
        }

        public bool Delete(User user)
        {
            _Context.Remove(user);
            _Context.SaveChanges();
            return true;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _Context.Users.FindAsync(id);
        }
    }
}