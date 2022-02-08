using AuthorizationMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationMicroservice.Data
{
    public class UserDataProvider:IUserdataProvider
    {
        private readonly List<UserModel> users = new List<UserModel>() 
        {
            new UserModel{ Username="admin",Password="admin",IsEmployee=true},
            new UserModel{ Username="888881",Password="test@123",IsEmployee=false},
            new UserModel{ Username="888882",Password="test@123",IsEmployee=false},
            new UserModel{ Username="888883",Password="test@123",IsEmployee=false},
            new UserModel{ Username="888884",Password="test@123",IsEmployee=false},
            new UserModel{ Username="888885",Password="test@123",IsEmployee=false},
            new UserModel{ Username="888886",Password="test@123",IsEmployee=false}
        };

        public UserModel GetUserDetail(UserViewModel login)
        {
            return users.SingleOrDefault(x => x.Username == login.Username && x.Password == login.Password);
        }
    }
}
