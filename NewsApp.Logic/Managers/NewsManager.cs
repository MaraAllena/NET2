using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsApp.Logic.Managers
{
    public class NewsManager

    {
        public static List<News> GetAll()
        {
            using (var db = new DbContext())
            {
                return db.News.ToList();
            }

        }

        public static void Create(string title, string description)
        {
            using (var db = new DbContext())
            {
                db.News.Add(new News()
                {
                    Title = title,
                    Description = description,
                });
                db.SaveChanges();
            }
        }
    }
}
