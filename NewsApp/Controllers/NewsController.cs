using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsApp.Logic;
using NewsApp.Logic.Managers;
using NewsApp.Models;

namespace NewsApp.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            
            var news = NewsManager.GetAll().Select(c => c.ToModel()).ToList();
            return View(news);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            var model = new NewsModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(NewsModel model)
        {
            if (ModelState.IsValid)
            {
                
                NewsManager.Create(model.Title, model.Description);
                return RedirectToAction(nameof(List));
            }

            return View(model);
        }
    }
}