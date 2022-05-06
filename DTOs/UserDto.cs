using System.Collections.Generic;

namespace WebAPI.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        
    }

    public class UserRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public IList<int> RolesId { get; set; } = new List<int>();
    }

    public class UserLoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserResponseModel:BaseResponse
    {
        public UserDto Data { get; set; }
    }

    public class UsersResponseModel : BaseResponse
    {
        public IList<UserDto> Data { get; set; } = new List<UserDto>();
    }
}