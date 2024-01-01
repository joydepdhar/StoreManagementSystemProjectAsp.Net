using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ICart<Type, CustomerID, ProductID, RET>
    {
        bool Create(Type obj);

        List<Type> Read();

        Type Read(CustomerID id);
        bool Update(Type Obj);

        bool Delete(CustomerID CustomerID, ProductID ProductID);
        bool Delete1(CustomerID UserID);
    }
}
