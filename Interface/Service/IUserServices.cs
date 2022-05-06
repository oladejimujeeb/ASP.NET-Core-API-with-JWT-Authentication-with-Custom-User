using System.Threading.Tasks;
using WebAPI.DTOs;
using WebAPI.Entities.Identity;

namespace WebAPI.Interface.Service
{
    public interface IUserServices
    {
        Task<BaseResponse> RegisterUser(UserRequestModel requestModel);
        Task<UserResponseModel> GetUserByID(int id);
        Task<UserResponseModel> GetUserByEmail(string email);
        
        Task<UsersResponseModel>  GetAllUsers();
        Task<BaseResponse> Update(UserRequestModel user);
        Task<bool> Delete(int id);
        Task<UserResponseModel> Login(UserLoginRequest loginRequest);
        Task<RolesResponseModel> GetRoleByUser(string email);
    }
}