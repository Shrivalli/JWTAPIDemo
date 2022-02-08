using AuthorizationMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationMicroservice.Data
{
    public interface IUserdataProvider
    {
        public UserModel GetUserDetail(UserViewModel login);
    }
}
