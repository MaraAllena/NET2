using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ItemCatalog.Models
{
    public class ItemsModel
    {
        public int Id { get; set; }
        
        [Required]
        [DataType(DataType.Text)]
        [StringLength(20)]
        [Display(Name = "Item: ")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [StringLength(300)]
        [Display(Description = "Description: ")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Price: ")]
        public decimal Price { get; set; }

        [DataType(DataType.Text)]
        [StringLength(300)]
        [Display(Name = "Location: ")]
        public string Location { get; set; }

        [Display(Name = "Category: ")]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string CategoriesName { get; set; }
        
        
        public CategoriesModel  Categories { get; set; }
    }
}
