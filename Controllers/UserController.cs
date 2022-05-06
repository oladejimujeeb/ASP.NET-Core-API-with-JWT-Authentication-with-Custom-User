using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;
using WebAPI.Interface.Service;

namespace WebAPI.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private IAuthentication _authentication;

        public UserController(IUserServices userServices, IAuthentication authentication)
        {
            _userServices = userServices;
            _authentication = authentication;
        }
        
        [HttpPost("Sign Up")]
        public async Task<IActionResult> CreateUser([FromBody]UserRequestModel requestModel)
        {
            var userSignUp = await _userServices.RegisterUser(requestModel);
            if (userSignUp.Status)
            {
                return Ok(userSignUp.Message);
            }

            return BadRequest(userSignUp.Message);
        }
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]UserLoginRequest requestModel)
        {
            var userLogin = await _userServices.Login(requestModel);
            if (userLogin.Status)
            {
                var login = new UserLoginResponse()
                {
                    UserName = userLogin.Data.Email,
                    Token = await _authentication.GenerateToken(userLogin.Data),
                    Data = userLogin.Data
                };
                return Ok(login);
            }

            return BadRequest(userLogin.Message);
        }
    }
}