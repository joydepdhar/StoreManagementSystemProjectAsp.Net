using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    internal interface ISearch<T>
    {
        List<T> Search(Dictionary<string, dynamic> Search);
    }
}
