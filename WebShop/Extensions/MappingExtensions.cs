using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Logic;

using WebShop.Models;

namespace WebShop
{
    public static class  MappingExtensions
    {

        public static CategoryModel ToCModel(this Categories c)
        {
            {
                return new CategoryModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    ParentId = c.ParentId
                };
            }
        }
        public static ItemModel ToIModel(this Items item)
        {
            {
                if (item == null)
                {
                    return null;
                }

                return new ItemModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    CategoryId = item.CategoryId,
                    Price = item.Price,
                    Description = item.Description,
                    Image = item.Image,
                    
                };
            }
        }
        public static UserModel ToUModel(this Users u)
        {
            {
                if(u == null)
                {
                    return null;
                }
                
                return new UserModel()
                {
                    Id = u.Id,
                    Email = u.Email,
                    Name = u.Name,
                    IsAdmin = u.IsAdmin,
                    //Password = u.Password
                };
            }
        }

        public static UserCart ToModel(this UserCart cart)
        {
            return new UserCart()
            {
                UserId = cart.UserId,
                ItemId = cart.ItemId
            };
        }
    }
}
