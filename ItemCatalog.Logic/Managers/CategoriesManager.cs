using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemCatalog.Logic
{
    public class CategoriesManager
    {
        public static List<Categories> GetAll()
        {
            using (var db = new DbContext())
            {

                return db.Categories.OrderBy(c => c.Name).ToList();
            }
        }

        public static void Create(string name)
        {
            using (var db = new DbContext())
            {
                db.Categories.Add(new Categories()
                {
                    Name = name,
                });

                db.SaveChanges();

            }
        }

    }
}
