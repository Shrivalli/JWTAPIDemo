using AuthorizationMicroservice.Data;
using AuthorizationMicroservice.Models;
using AuthorizationMicroservice.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserDataProvider _userDataProvider;
       
        
        public AuthorizationController(IConfiguration config, UserDataProvider userDataProvider)
        {
            _config = config;
            _userDataProvider = userDataProvider;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(UserViewModel login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                
                response = Ok(new LoginResponse{ token = tokenString, User_Id = login.Username ,Role=user.IsEmployee});
            }

            return response;
        }

        private string GenerateJSONWebToken(UserModel userInfo)
        {

            if (userInfo is null)
            {
                throw new ArgumentNullException(nameof(userInfo));
            }
            List<Claim> claims = new List<Claim>();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            claims.Add(new Claim("Username", userInfo.Username));
            if(userInfo.IsEmployee)
            { 
            claims.Add(new Claim("role", "admin"));
            }
            else
            {
                claims.Add(new Claim("role", "POC"));

            }
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(2),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel AuthenticateUser(UserViewModel login)
        {
            UserModel user = _userDataProvider.GetUserDetail(login);
            return user;
        }

       
    }
}
