using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs;
using WebAPI.Entities.Identity;
using WebAPI.Interface.Repository;
using WebAPI.Interface.Service;

namespace WebAPI.Implementation.Services
{
    public class RoleServices:IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleServices(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<RoleResponseModel> CreateRole(RoleRequestModel model)
        {
            var role = new Role()
            {
                Description = model.Description,
                RoleName = model.RoleName
            };
            var addRole = await _roleRepository.CreateRole(role);
            if (addRole != null)
            {
                return new RoleResponseModel()
                {
                    Message = "Successfully Added",
                    Status = true,
                };
            }

            return new RoleResponseModel() {Status = false,Message = "failed"};

        }

        public async Task<RolesResponseModel> GetAllRoles()
        {
            var role = await _roleRepository.GetAllRoles();
            var allrole = role.Select(x => new RoleDto
            {
                Description = x.Description,
                Id = x.Id,
                RoleName = x.RoleName
            }).ToList();
            return new RolesResponseModel()
            {
                Status = true,
                Data = allrole
            };
        }

        public async Task<RoleResponseModel> GetRole(int id)
        {
            var getRole = await _roleRepository.GetRole(id);
            if (getRole != null)
            {
                return new RoleResponseModel()
                {
                    Status = true,
                    Message = "Successful",
                    Data = new RoleDto()
                    {
                        Id = getRole.Id,
                        Description = getRole.Description,
                        RoleName = getRole.RoleName
                    }
                };
            }

            return new RoleResponseModel()
            {
                Status = false,
                Message = "Role not found"
            };
        }

        public Task<RoleResponseModel> DeleteRole(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<RolesResponseModel> GetRolesByRoleIds(UserRequestModel model)
        {
            var roles = await _roleRepository.GetRolesByRoleIds(model.RolesId);
            var sRoles = roles.Select(x => new RoleDto()
            {
                Description = x.Description,
                Id = x.Id,
                RoleName = x.RoleName,
            }).ToList();
            return new RolesResponseModel() { Data = sRoles};
        }

        public async Task<RolesResponseModel> GetRoleByUser(string email)
        {
            var userEmail = await _roleRepository.GetRoleByUser(email);
            var allRoles = userEmail.Select(g=> new RoleDto()
            {
                RoleName = g.Role.RoleName
            }).ToList();

            if (allRoles != null)
            {
                return new RolesResponseModel()
                {
                    Status = true,
                    Data = allRoles,
                    Message = "User Roles"
                };
            }

            return new RolesResponseModel()
            {
                Status = false,Message = "No info"
            };
        }
            
        
    }
}