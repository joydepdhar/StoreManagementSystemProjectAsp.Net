using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos
{
    public class OrderRepo : Repo, IRepo<Order, int, bool>
    {
        public bool Create(Order obj)
        {
            db.Orders.Add(obj);
            if (db.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool Delete(int Id)
        {
            var ex = Read(Id);
            db.Orders.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Order> Read()
        {
            return db.Orders.ToList();
        }

        public Order Read(int Id)
        {
            return db.Orders.Find(Id); ;
        }

        public bool Update(Order Obj)
        {
            var ex = Read(Obj.Id);
            db.Entry(ex).CurrentValues.SetValues(Obj);
            if (db.SaveChanges() > 0)
                return true;
            return false;
        }
    }
}
