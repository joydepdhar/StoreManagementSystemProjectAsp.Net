using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos
{
    public class ManageOrderRepo : Repo, IOrder<Order, int, Order>
    {
        public object CustomrOrder { get; private set; }

        public Order Create(Order obj)
        {
            db.Orders.Add(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrderDetails()
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrderDetails(int id)
        {
            //var query = (from CustomerOrder in db.CustomerOrders
            //           where CustomerOrder.CustomerID == id
            //         select CustomrOrder).FirstOrDefault();
            //var order = (from o in db.Orders
            //           where o.Id == query.
            //         select o).ToList();
            var query = (from customerOrder in db.CustomerOrders
                         where customerOrder.CustomerID == id
                         select customerOrder).FirstOrDefault();
            var order = (from o in db.Orders
                          where o.Id == query.OrderID
                          select o).ToList();
            return order;
        }

        public Order Update(Order Obj)
        {
            throw new NotImplementedException();
        }
    }
}
