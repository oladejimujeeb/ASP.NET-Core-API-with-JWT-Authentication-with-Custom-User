using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs;
using WebAPI.Entities.Identity;
using WebAPI.Interface.Repository;
using WebAPI.Interface.Service;

namespace WebAPI.Implementation.Services
{
    public class UserServices:IUserServices
    {
        private readonly IUser _user;
        private readonly IRoleService _roleService;

        public UserServices(IUser user, IRoleService roleService)
        {
            _user = user;
            _roleService = roleService;
        }
        public async Task<BaseResponse> RegisterUser(UserRequestModel requestModel)
        {
            var confirmMail = await _user.ComfirmEmail(requestModel.Email);
            if (confirmMail)
            {
                return new BaseResponse() { Message = "Email Already Exist", Status = false};
            }
            
            var user = new User()
            {
                Email = requestModel.Email,
                Password = requestModel.Password,
                FirstName = requestModel.FirstName,
                PhoneNumber = requestModel.PhoneNumber,
                LastName = requestModel.LastName,
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
            };
            var allRoles = await _roleService.GetRolesByRoleIds(requestModel);
            
            var roles = allRoles.Data;
            foreach (var role in roles)
            {
                var userRole = new UserRole()
                {
                    
                    RoleId = role.Id,
                    
                    UserId = user.Id
                };
                user.UserRoles.Add(userRole);
            }

            var addUser = await _user.ResgisterUser(user);
            if (addUser != null)
            {
                return new BaseResponse() {Status = true, Message = $"User: {addUser.Email} Added successfully"};
            }

            return new BaseResponse() {Status = false, Message = "failed to add user"};
        }

        public async Task<UserResponseModel> GetUserByID(int id)
        {
            var getUser = await _user.GetUserById(id);
            if (getUser != null)
            {
                return new UserResponseModel()
                {
                    Message = "Account Found",
                    Status = true,
                    Data = new UserDto()
                    {
                        FirstName = getUser.FirstName,
                        LastName = getUser.LastName,
                        Password = getUser.Password,
                        Email = getUser.Email,
                        Id = getUser.Id,
                        EmailConfirmed = getUser.EmailConfirmed,
                        PhoneNumber = getUser.PhoneNumber,
                        PhoneNumberConfirmed = getUser.PhoneNumberConfirmed
                    }
                };
            }

            return new UserResponseModel()
            {
                Message = "Account Not Found",
                Status = false
            };
        }

        public async Task<UserResponseModel> GetUserByEmail(string email)
        {
            var getUser = await _user.GetUser(email);
            if (getUser != null)
            {
                return new UserResponseModel()
                {
                    Message = "Account Found",
                    Status = true,
                    Data = new UserDto()
                    {
                        FirstName = getUser.FirstName,
                        LastName = getUser.LastName,
                        Password = getUser.Password,
                        Email = getUser.Email,
                        Id = getUser.Id,
                        EmailConfirmed = getUser.EmailConfirmed,
                        PhoneNumber = getUser.PhoneNumber,
                        PhoneNumberConfirmed = getUser.PhoneNumberConfirmed
                    }
                };
            }

            return new UserResponseModel()
            {
                Message = "Account Not Found",
                Status = false
            };
        }

        public async Task<UsersResponseModel> GetAllUsers()
        {
            var allUsers = await _user.GetAllUsers();
            var allUsersReturned = allUsers.Select(g=> new UserDto()
            {
                FirstName = g.FirstName,
                LastName = g.LastName,
                Password = g.Password,
                Email = g.Email,
                Id = g.Id,
                EmailConfirmed = g.EmailConfirmed,
                PhoneNumber = g.PhoneNumber,
                PhoneNumberConfirmed = g.PhoneNumberConfirmed
            }).ToList();
            
            return new UsersResponseModel()
            {
                Status = true,
                Message= "Retrieval success",
                Data = allUsersReturned
            };
        }

        public Task<BaseResponse> Update(UserRequestModel user)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            var getUser = await _user.GetUserById(id);
            if (getUser==null)
            {
                return false;
            }
            _user.Delete(getUser);
            return true;
        }

        public async Task<UserResponseModel> Login(UserLoginRequest loginRequest)
        {
            var getUser = await _user.GetUser(loginRequest.Email);
            
            if (getUser!=null && getUser.Password == loginRequest.Password)
            {
                return new UserResponseModel()
                {
                    Message = "Login Found",
                    Status = true,
                    Data = new UserDto()
                    {
                        FirstName = getUser.FirstName,
                        LastName = getUser.LastName,
                        Password = getUser.Password,
                        Email = getUser.Email,
                        Id = getUser.Id,
                        EmailConfirmed = getUser.EmailConfirmed,
                        PhoneNumber = getUser.PhoneNumber,
                        PhoneNumberConfirmed = getUser.PhoneNumberConfirmed
                    }
                };
            }

            return new UserResponseModel()
            {
                Message = "Invalid UserName or Password",
                Status = false
            };
        }

        public Task<RolesResponseModel> GetRoleByUser(string email)
        {
            throw new System.NotImplementedException();
        }

        /*public async Task<RolesResponseModel> GetRoleByUser(string email)
        {
            var userRole = await _roleService.GetRoleByUser(email);
            var allRoles = userRole.Select(g=> new RoleDto()
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
        }*/
    }
}