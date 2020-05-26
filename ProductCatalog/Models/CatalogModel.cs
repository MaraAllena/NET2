using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.Models
{
    public class CatalogModel
    {
        public int Id { get; set; }

        public string Product { get; set; }

        public string Description { get; set; }

        public string Price { get; set; }

    }
}
