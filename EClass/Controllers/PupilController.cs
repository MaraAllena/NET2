using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EClass.Logic;
using EClass.Extensions;
using EClass.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;

namespace EClass.Controllers
{
    public class PupilController : Controller
    {

        public IActionResult Index()
        {
            var pupils = PupilManager.GetAll().Select(p => p.ToModelP()).ToList();

            return View(pupils);
        }

        public IActionResult Add()
        {
            var model = new PupilModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(PupilModel model)
        {
            if (ModelState.IsValid)
            {
                var pup = PupilManager.Get(model.Name, model.Surname);

                if (pup != null)
                {
                    ModelState.AddModelError("err", "Pupil already exists in List!");
                }

                else
                {
                    PupilManager.Create(model.Name, model.Surname, model.Birthyear, model.ClassNumber);
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }

    }

}
    
 
    