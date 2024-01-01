using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos
{
    internal class ManageCustomerOrderRepo : Repo, ICart<CustomerOrder, int, int, bool>
    {
        public bool Create(CustomerOrder obj)
        {
            db.CustomerOrders.Add(obj);
            if (db.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool Delete(int CustomerID, int ProductID)
        {
            var CustomerOrder = db.CustomerOrders
                            .SingleOrDefault(c => c.Id == CustomerID);
            if (CustomerOrder != null)
            {
                db.CustomerOrders.Remove(CustomerOrder);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public bool Delete1(int UserID)
        {
            throw new NotImplementedException();
        }

        public List<CustomerOrder> Read()
        {
            return db.CustomerOrders.ToList();
        }

        public CustomerOrder Read(int id)
        {
            return db.CustomerOrders.Find(id);
        }

        public bool Update(CustomerOrder Obj)
        {
            var ex = Read(Obj.Id);
            db.Entry(ex).CurrentValues.SetValues(Obj);
            if (db.SaveChanges() > 0)
                return true;
            return false;
        }
    }
}
