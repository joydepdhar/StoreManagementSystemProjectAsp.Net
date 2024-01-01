using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IAuth<RET>
    {
        RET Authenticate(string Email, string Password);
    }
}
