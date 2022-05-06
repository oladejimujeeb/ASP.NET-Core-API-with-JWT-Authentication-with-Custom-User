using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.DTOs;
using WebAPI.Entities.Identity;

namespace WebAPI.Interface.Repository
{
    public interface IRoleRepository
    {
        Task<Role> CreateRole(Role role);
        Task<bool> DeleteItem(Role role);
        Task<Role> EditItem(Role role);
        Task<IList<Role>> GetAllRoles();
        Task<Role> GetRole(int id);
        Task<IList<Role>> GetRolesByRoleIds(IList<int> roleIDs);
        Task<IList<UserRole>> GetRoleByUser(string email);
        //Task<IList<Role>> GetRolesBySelectedCategory(IList<int>categoryIds);
    }
}