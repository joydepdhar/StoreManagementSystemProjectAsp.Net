using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IRepo<Type,ID,RET>
    {
        RET Create(Type obj);

        List<Type> Read();
        Type Read(ID Id);
        RET Update(Type obj);
        bool Delete(ID Id);


    }
}
