using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace ItemCatalog.Logic
{
    public class ItemManager
    {
        public static List<Items> GetAll()
        {
            using (var db = new DbContext())
            {

                return db.Items.OrderBy(i => i.Price).ToList();
            }
        }

        public static Items Get(int id)
        {
            using (var db = new DbContext())
            {

                return db.Items.Find(id);
            }
        }

        public static Categories Find(string CategoriesName)
        {
            using (var db = new DbContext())
            {
                return db.Categories.FirstOrDefault(c => c.Name == CategoriesName);
            }
        }

        public static void Create(string name, string description, decimal price, string location, int Id)
        {
            using (var db = new DbContext())
            {
                db.Items.Add(new Items()
                {
                    Name = name,
                    Description = description,
                    Price = price,
                    Location = location,
                    CategoryId = Id,
                });
                db.SaveChanges();
            }
        }
    }
}