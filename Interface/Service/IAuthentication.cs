using System.Threading.Tasks;
using WebAPI.DTOs;

namespace WebAPI.Interface.Service
{
    public interface IAuthentication
    {
        Task<string> GenerateToken(UserDto user);
        //int UserId();
    }
}