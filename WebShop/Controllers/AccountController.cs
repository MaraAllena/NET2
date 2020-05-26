using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShop.Logic;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult SignUp()
        {
            var model = new UserModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult SignUp(UserModel model)
        {
            if(ModelState.IsValid)
            {
                //pārbauda vai paroles sakrīt
                //vai ar šādu epastu jau neeksistē
                                
                if (model.Password != model.PasswordRepeat)
                {
                    ModelState.AddModelError("pass", "Passwords do not match!");
                }
                else
                {
                    //lietotāja atlase no DB pēc e-pasta. Izmantojot UserManager.
                    
                    UserModel user = UserManager.GetByEmail(model.Email).ToUModel();
                    
                    if (user!=null)//ja lietotājs nav null
                    {
                        ModelState.AddModelError("mail", "User with this e-mail already exists!");
                    }
                    
                    else 
                    {
                        //saglabāt ievadītos datus DB. Izmantojot UserManager

                        UserManager.Create(model.Email, model.Name, model.Password);
                        
                        return RedirectToAction(nameof(SignIn));
                    }
                }
            }    
            return View();
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            var model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult SignIn(LoginModel model)
        {
            if (ModelState.IsValid)

            {
                //lietotāja atlase no DB pēc epasta un paroles. Izmantojot Usermanager
                UserModel user = UserManager.GetByEmailAndPassword(model.Email, model.Password).ToUModel();
                
                if (user == null)
                {
                    ModelState.AddModelError("user", "Invalid e-mail/password!");
                }
                else
                {
                    //saglabāt datus sesijā
                    HttpContext.Session.SetUserName(user.Name);
                    HttpContext.Session.SetUserId(user.Id);
                    HttpContext.Session.SetIsAdmin(user.IsAdmin);

                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult MyCart()
        {
            //veikt lietotāja groza atlasi no DB, izmantojot usercartmanaget get by user

            var userCart = UserCartManager.GetByUser(HttpContext.Session.GetUserId());

            //japarveido uz modeli, attēlojot groza saturu
            var items = userCart.Select(c => c.Item.ToIModel()).ToList();

            
            
            foreach (var item in items)
            {
                item.Quantity = UserCartManager.GetItemQuantity(item.Id);
            }

            //jāattēlo tikai preces
            return View(items);
        }

        public IActionResult Confirm ()
        {
            UserCartManager.Clear();
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            UserCartManager.Delete(id);
            return RedirectToAction(nameof(MyCart));
        }
    }
}