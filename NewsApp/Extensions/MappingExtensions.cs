using NewsApp.Logic;
using NewsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp
{
    public static class MappingExtensions
    {
        public static AccountModel ToModel(this Users u)
        {
            {
                if (u == null)
                {
                    return null;
                }

                return new AccountModel()
                {
                    Id = u.Id,
                    Email = u.Email,
                    Password = u.Password,
                    IsAdmin = u.IsAdmin,
                    
                };
            }
        }
        public static NewsModel ToModel(this News n)
        {
            {
                if (n == null)
                {
                    return null;
                }

                return new NewsModel()
                {
                    Id = n.Id,
                    Title = n.Title,
                    Description = n.Description,

                };
            }
        }


    }
}
