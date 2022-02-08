using AuthorizationMicroservice.Data;
using AuthorizationMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationMicroservice.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserDataProvider _userDataProvider;
        public AuthService(UserDataProvider userDataProvider)
        {
            _userDataProvider = userDataProvider;
        }
        public UserModel GetUserDetail(UserViewModel login)
        {
            UserModel user = null;
            user = _userDataProvider.GetUserDetail(login);
            return user;
        }
    }
}
