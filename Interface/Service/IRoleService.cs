using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.DTOs;

namespace WebAPI.Interface.Service
{
    public interface IRoleService
    {
        Task<RoleResponseModel> CreateRole(RoleRequestModel model);
        Task<RolesResponseModel> GetAllRoles();
        Task<RoleResponseModel> GetRole(int id);
        Task<RoleResponseModel> DeleteRole(int id);
        Task<RolesResponseModel> GetRolesByRoleIds(UserRequestModel model);
        Task<RolesResponseModel> GetRoleByUser(string email);
    }
}