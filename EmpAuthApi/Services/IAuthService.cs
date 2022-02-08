using AuthorizationMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationMicroservice.Services
{
    public interface IAuthService
    {
        public UserModel GetUserDetail(UserViewModel login);
    }
}
