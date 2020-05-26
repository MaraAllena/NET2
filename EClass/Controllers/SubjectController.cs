using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EClass.Logic;
using EClass.Extensions;
using EClass.Models;
using Microsoft.AspNetCore.Mvc;

namespace EClass.Controllers
{
   public class SubjectController : Controller
    {
        //public static List<SubjectModel> Subjects = new List<SubjectModel>();

        public IActionResult Index()
        {
           var subj = SubjectManager.GetAll().Select(i => i.ToModelS()).ToList();
           return View(subj);
            
        }

        public IActionResult Add()
        { 
            var model = new SubjectModel();
            return View(model);
        }
        
        [HttpPost]
        public IActionResult Add(SubjectModel model)
        {
            if (ModelState.IsValid)
            {
                var sub = SubjectManager.Get(model.Name);
                
                if (sub != null)
                {
                    ModelState.AddModelError("err", "Subject already exists in List!");
                }

                else
                {
                    SubjectManager.Create(model.Name);
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }
    }
}
