
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WebShop.Logic
{
    public class UserCartManager
    {
        public static void Create(int userId, int itemId)
        {
            using (var db = new DbContext())
            {
               
                
                db.UserCart.Add(new UserCart()
                {
                    UserId = userId,
                    ItemId = itemId,
                });

                db.SaveChanges();
            }
        }
        public static Items Get(int id)
        {
            using (var db = new DbContext())
            {
                return db.Items.FirstOrDefault(c => c.Id == id);
            }
        }

        public static List<UserCart> GetByUser(int userId)
        {
            using (var db = new DbContext())
            {
                // atlasa lietotāja groza ierakstus
                //var userCart = db.UserCart.Where(c => c.UserId == userId).ToList();

                // katram groza ierakstam atlasa atbilstošā 'Item' datus
                // TODO: izmantot SQL join
                //foreach (var item in userCart)
                //{
                //item.Item = db.Items.Find(item.ItemId);
                //}

                // from UserCart where UserId
                //from Items where Id = ItemId
                //neefektīvi
                //SQL JOIN - datu atlase vienā pieprasījumā
                //
                var userCart = db.UserCart.Where(c => c.UserId == userId)
                    .Join(db.Items, c => c.ItemId, i => i.Id, (c, i) => new UserCart()
                    {
                        Item = i
                    }).ToList();


                return userCart;
            }
        }
        public static void Delete(int id)
        {
            using (var db = new DbContext())
            {
                db.UserCart.Remove(db.UserCart.FirstOrDefault(i => i.ItemId == id));
                db.SaveChanges();
            }
        }
        public static void Clear()
        {
            using (var db = new DbContext())
            {
                
                    db.UserCart.RemoveRange(db.UserCart);
                    db.SaveChanges();
                
            }
        }

        public static int GetItemQuantity(int id)
        {
            using (var db = new DbContext())
            {

                return db.UserCart.Count(i => i.ItemId == id);
            }

        }
    }
}
