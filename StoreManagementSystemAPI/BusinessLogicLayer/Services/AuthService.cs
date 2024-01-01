using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class AuthService
    {
        public static bool Authentication(string Email, string Password)
        {
            return DataAccessFactory.AuthData().Authenticate(Email, Password);
        }
    }
}
