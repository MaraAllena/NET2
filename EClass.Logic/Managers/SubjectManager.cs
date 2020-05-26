using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EClass.Logic
{
    public class SubjectManager
    {
        public static List<Subjects> GetAll()
        {
            using (var db = new DbContext())
            {
                return db.Subjects.OrderBy(e => e.Name).ToList();
            }
        }

        public static void Create(string name)
        {
            using (var db = new DbContext())
            {
                
                db.Subjects.Add(new Subjects()
                {
                    Name = name,
                });

                db.SaveChanges();
            }
        }

        public static Subjects Get(string name)
        {
            using (var db = new DbContext())
            {
                return db.Subjects.FirstOrDefault(u => u.Name == name);
            }

        }




    }
}
