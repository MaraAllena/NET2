using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsApp.Logic
{
    public class UserManager
    {
        public static Users GetByEmailAndPassword(string email, string password)
        {
            using (var db = new DbContext())
            {
                return db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            }

        }

        public static Users GetAdmin(bool isAdmin)
        {

            using (var db = new DbContext())
            {
                return db.Users.FirstOrDefault(u => u.IsAdmin == isAdmin);
            }

        }
    }
}
