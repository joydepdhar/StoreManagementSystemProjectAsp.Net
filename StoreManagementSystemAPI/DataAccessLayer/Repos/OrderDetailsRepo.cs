using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos
{
    internal class OrderDetailsRepo : Repo, IRepo<OrderDetails, int, bool>, ITop<OrderDetails>
    {
        public bool Create(OrderDetails obj)
        {
            db.OrderDetailss.Add(obj);
            if (db.SaveChanges() > 0)
                return true;
            return false; ;
        }

        public bool Delete(int Id)
        {
            var ex = Read(Id);
            db.OrderDetailss.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<OrderDetails> GetList()
        {
            var list = (from x in db.OrderDetailss
                        where x.Status.Equals("Approved")
                        select x).ToList();
            return list;
        }

        public List<OrderDetails> Read()
        {
            return db.OrderDetailss.ToList();
        }

        public OrderDetails Read(int Id)
        {
            return db.OrderDetailss.Find(Id);
        }

        public bool Update(OrderDetails obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
                return true;
            return false;
        }
    }
}
