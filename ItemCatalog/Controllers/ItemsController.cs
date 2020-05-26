using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemCatalog;
using ItemCatalog.Logic;
using ItemCatalog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ItemCatalog.Controllers
{
    public class ItemsController : Controller
    {

        //id--> kategorijas Id
        public IActionResult Index(int? Id)// nullējama vērtība, Id var nebūt definēts
        {
            /*using (var db = new DbContext())
            {
                var item = db.Items.OrderBy(i => i.Price). */

            var item = ItemManager.GetAll().Select(i => i.ToIModel()).ToList();

            if (Id.HasValue)//vai paliek?
            {
                item = item.Where(c => c.Categories.Id == Id).ToList();
            }
            return View(item);

            //var model = Items
            //.OrderBy(i => i.Price)
            //.ToList();
            // ja nav id, salike preces pēc cenas   
            //if (Id.HasValue)
            //{
            //model = model.Where(i => i.Categories.Id == Id).ToList();
            //};
            //return View(model);
        }


        public IActionResult View(int id)
        {
            var item = ItemManager.Get(id).ToIModel();
            return View(item);

            /*using (var db = new DbContext())
            {

                var i = db.Items.Find(Id);
                var item = new ItemsModel()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    Price = i.Price,
                    Location = i.Location,
                    Categories = new CategoriesModel()
                    {
                        Id = i.CategoryId
                    }
                };*/

        }
        //var model = Items.Find(i => i.Id == Id);
        //return View(model);


        public IActionResult Add()
        {
            var item = new ItemsModel();
            return View(item);

        }

        [HttpPost]
        public IActionResult Add(ItemsModel model)
        {
            if (ModelState.IsValid)
            {
                var category = ItemManager.Find(model.CategoriesName);

                if (category != null)
                {
                    ItemManager.Create(model.Name, model.Description, model.Price, model.Location, category.Id);
                    return RedirectToAction("Index");
                }

                else
                {
                    ModelState.AddModelError("cat", "Category not found!");
                }
            }

            return View(model);
                }
                    /*using (var db = new DbContext())
                {
                    var category = db.Categories.FirstOrDefault(c => c.Name == model.CategoriesName);
                    {
                        if (category != null)

                        {
                            db.Items.Add(new Items()
                            {
                                Name = model.Name,
                                Description = model.Description,
                                Price = model.Price,
                                Location = model.Location,
                                CategoryId = category.Id

                            });
                            db.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("cat", "Category not found!");
                        }
                        //model.Categories = CategoriesController.Categories.Find(c => c.Name == model.CategoriesName);
                        //if(model.Categories != null)
                        //{ 
                        //model.Id = Items.Count + 1;

                        //Items.Add(model);
                        //return RedirectToAction("Index");
                        //}
                        //else
                        //{
                        //ModelState.AddModelError("cat", "Category not found!");
                        //}*/

                    }

                }

