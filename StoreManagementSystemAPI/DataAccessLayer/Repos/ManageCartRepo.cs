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
    public class ManageCartRepo : Repo ,ICart<Cart, int, int, Cart>
    {
        public bool Create(Cart obj)
        {
            db.Carts.Add(obj);
            if (db.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool Delete(int CustomerID, int ProductID)
        {
            var cartItem = db.Carts.SingleOrDefault(c => c.CustomerID ==CustomerID && c.ProductID == ProductID);
            if (cartItem != null)
            {
                db.Carts.Remove(cartItem);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public bool Delete1(int CustomerID)
        {
            throw new NotImplementedException();
        }

        public List<Cart> Read()
        {
            return db.Carts.ToList();
        }

        public Cart Read(int id)
        {
            return db.Carts.Find(id);
        }

        public bool Update(Cart Obj)
        {
            var ex = Read(Obj.Id);
            db.Entry(ex).CurrentValues.SetValues(Obj);
            if (db.SaveChanges() > 0)
                return true;
            return false;
        }
    }
}
