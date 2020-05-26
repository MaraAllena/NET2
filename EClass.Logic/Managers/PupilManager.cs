using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EClass.Logic
{
    public class PupilManager
    {
        public static List<Pupils> GetAll()
        {
            using (var db = new DbContext())
            {
                return db.Pupils.OrderBy(i => i.Surname).ThenBy(e => e.Name).ToList();
            }
        }

        public static void Create(string name, string surname, string birthyear, int classnumber)
        {
            using (var db = new DbContext())
            {
                db.Pupils.Add(new Pupils()
                {
                    Name = name,
                    Surname = surname,
                    Birthyear = birthyear,
                    ClassNumber = classnumber
                });

                db.SaveChanges();
            }
        }

        public static Pupils Get(string name, string surname)
        {
            using (var db = new DbContext())
            {
                return db.Pupils.FirstOrDefault(u => u.Name == name && u.Surname == surname);
            }

        }


    }
}
