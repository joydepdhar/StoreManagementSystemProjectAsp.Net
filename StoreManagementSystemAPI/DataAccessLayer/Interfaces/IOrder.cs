using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IOrder<Type, ID, RET>
    {
        RET Create(Type obj);

        List<Type> GetOrderDetails();

        List<Type> GetOrderDetails(ID id);

        RET Update(Type Obj);

        bool Delete(ID id);

    }
}
