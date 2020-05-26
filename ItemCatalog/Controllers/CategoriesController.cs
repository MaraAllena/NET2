using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using ItemCatalog.Logic;
using ItemCatalog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Remotion.Linq.Clauses.ExpressionVisitors;

namespace ItemCatalog.Controllers
{
    public class CategoriesController : Controller
    {

        //1.a
        public IActionResult Index()
        {
            var category = CategoriesManager.GetAll()
                .Select(c => c.ToCModel()).ToList();
            return View(category);

            /*using (var db = new DbContext())
            {
                var category = db.Categories.OrderBy(c => c.Name)
                    .Select(c => new CategoriesModel()
                    {
                        Id = c.Id,
                        Name = c.Name,
                    })
                    .ToList();
               return View(category);     
             */
            //var category = Categories.OrderBy(c => c.Id).ToList();
            //return View(category);
        }

        public IActionResult Add()
        {
            var category = new CategoriesModel();
            return View(category);
        }

        [HttpPost]
        public IActionResult Add(CategoriesModel model)
        {
            if (ModelState.IsValid)
            {
                CategoriesManager.Create(model.Name);
                return RedirectToAction("Index");
                /*using (var db = new DbContext())
                {
                    db.Categories.Add(new Categories()
                    {
                        Name = model.Name,
                    });

                    db.SaveChanges();

                }*/
                //model.Id = Categories.Count + 1;

                //modelis derīgs, var veikt datu saglabāšanu
                //Categories.Add(model);
            }

            return View(model);
        }
    }
}
