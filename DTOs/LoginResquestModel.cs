namespace WebAPI.DTOs
{
    public class LoginRequestModel
    {
        public string UserName{get; set;}
        public string Password{get; set;}
    }
    public class UserLoginResponse
    {
        public string UserName{get; set;}
        public string Token{get; set;}
        public UserDto Data{get;set;}
    }
}