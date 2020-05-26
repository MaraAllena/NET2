using ItemCatalog.Logic;
using ItemCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemCatalog
{
    public static class MappingExtensions

    {
        public static ItemsModel ToIModel(this Items i)
        {
            return new ItemsModel()
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description,
                Price = i.Price,
                Location = i.Location,
                Categories = new CategoriesModel()
                {
                Id = i.CategoryId,
                }
            };
        }

        public static CategoriesModel ToCModel(this Categories c)
        {
            {
                return new CategoriesModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                };
            }
        }
    }
}
