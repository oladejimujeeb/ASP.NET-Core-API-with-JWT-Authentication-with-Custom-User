using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebAPI.DTOs;
using WebAPI.Entities.Identity;
using WebAPI.Interface.Service;


namespace WebAPI.Implementation.Services
{
    public class Authentication:IAuthentication
    {
        private readonly IConfiguration _configuration;
        //private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserServices _userServices;
        private readonly IRoleService _roleService;

        public Authentication(IConfiguration configuration, IUserServices userServices, IRoleService roleService)
        {
            _configuration = configuration;
            _userServices = userServices;
            _roleService = roleService;
        }

       
        public async Task<string> GenerateToken(UserDto user)
        {
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var securityKey = new SymmetricSecurityKey(tokenKey);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            //var loginUser = await _userServices.GetUser(user.Id);
            
            var roleClaim = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            };
            
            var role = await _roleService.GetRoleByUser(user.Email);
            var roles = role.Data;
            foreach (var rol in roles)
            {
                roleClaim.Add(new Claim(ClaimTypes.Role, rol.RoleName));
            }

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                roleClaim, 
                //notBefore:DateTime.Now,
                expires:DateTime.Now.AddMinutes(2),
                signingCredentials:credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /*public int UserId()
        {
            var user = _contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name);
            return Convert.ToInt32(user);
        }*/
    }
}