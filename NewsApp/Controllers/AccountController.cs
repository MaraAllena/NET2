using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewsApp.Logic;
using NewsApp.Models;

namespace NewsApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            var model = new AccountModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult SignIn(AccountModel model)
        {
            if (ModelState.IsValid)

            {
                //lietotāja atlase no DB pēc epasta un paroles. Izmantojot Usermanager
                AccountModel user = UserManager.GetByEmailAndPassword(model.Email, model.Password).ToModel();

                if (user == null)
                {
                    ModelState.AddModelError("user", "Invalid e-mail/password!");
                }
                else
                {
                    HttpContext.Session.SetUserEmail(user.Email);
                    HttpContext.Session.SetIsAdmin(user.IsAdmin);
                    return RedirectToAction("List", "News");
                }
            }
            return View(model);
        }
        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}