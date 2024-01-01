using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos
{
    internal class UserRepo : Repo, IRepo<User, int, User>,IAuth<bool>
    {
        public User Create(User obj)
        {
            db.Users.Add(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }

        public bool Delete(int Id)
        {
            var ex = Read(Id);
            db.Users.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<User> Read()
        {
            return db.Users.ToList();
        }

        public User Read(int Id)
        {
            return db.Users.Find(Id);
        }

        public User Update(User obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
        public bool Authenticate(string Email, string Password)
        {
            var data = (from u in db.Users
                        where u.Email.Equals(Email) && u.Password.Equals(Password)
                        select u).SingleOrDefault();
            if (data != null) return true;
            return false;
        }
    }
}
