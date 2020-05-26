using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWeb.Logic;
using FirstWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstWeb.Controllers
{
    public class UserController : Controller
    {
        //public static List<UserModel> Users = new List<UserModel>();
        
        public IActionResult Index()
        // https://localhost:44304/User/Index
        {
            var users = UserManager.GetAll().Select(u => u.ToModel()).ToList();
            return View(users);
            
            /*using(var db = new DbContext())
            {
            var users = db.Users.Select(u => new UserModel()
            var users = UserManager.GetAll().Select(u => new UserModel()
            
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    Phone = u.Phone,
                }).ToList();
            }

            return View(users);*/
        }

        public IActionResult View(int id)
            //apskatīt konkrētu lietotāju
            //https://localhost:44304/User/View/2
            //2 - Id
        {
            var user = UserManager.Get(id).ToModel();
            return View(user);
            
            
            /*using(var db = new DbContext())
            {
            var u = db.Users.Find(id);
            var user = new UserModel()
            var user = .ToModel()
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    Phone = u.Phone,
                };
            }    
            var user = Users.Find(u => u.Id == id); */
        }
        //https://localhost:44304/User/Add
        public IActionResult Add()
        {
            
            var user = new UserModel();
            return View(user);
        }


        [HttpPost]
        public IActionResult Add(UserModel model)
        {
            if(ModelState.IsValid)
            {
                /*using (var db = new DbContext())
                {
               db.Users.Add(new Users()
                {
                Email = model.Email,
                Phone = model.Phone,
                Name = model.Name,
                });
                db.SaveChanges();
                }
                model.Id = Users.Count + 1; */
                //Viss ok modelis ir derīgs, var veikt datu saglabāšanu
                //Users.Add(model);
                
                UserManager.Create(model.Name, model.Email, model.Phone);
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}