using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Entities.Identity;

namespace WebAPI.Interface.Repository
{
    public interface IUser
    {
        Task<User> ResgisterUser(User user);
        Task<bool> ComfirmEmail(string username);
        Task<User> GetUserById(int id);
        Task<User> GetUser(string username);
        Task<IList<User>> GetAllUsers();
        User Update(User user);
        bool Delete (User user);
    }
}