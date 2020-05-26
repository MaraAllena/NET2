using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EClass.Logic;
using EClass.Extensions;
using EClass.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace EClass.Controllers
{
    public class GradeController : Controller
    {
        //public static List<GradeModel> Grades = new List<GradeModel>();

        public IActionResult Index()
        {
            var model = GradeManager.GetAll().Select(g => g.ToModelG())
            .ToList();
            return View(model);
        }

        public IActionResult Add()
        {
            var grade = new GradeModel();
            return View(grade);
        }

        [HttpPost]
        public IActionResult Add(GradeModel model)
        {
            if (ModelState.IsValid)
            {
                var sub = GradeManager.FindSub(model.SubjectTitle);
                var name = GradeManager.FindName(model.PupilsName);
                var surname = GradeManager.FindSurname(model.PupilsSurname);

                if (name != null && surname != null && sub != null && model.Grade > 0 && model.Grade < 11)
                {
                    GradeManager.Create(model.Grade, model.Description, model.PupilsName, model.PupilsSurname, model.SubjectTitle);
                    return RedirectToAction("Index");
                }

                else if (name == null || surname == null)
                {
                    ModelState.AddModelError("pup", "Pupil is not found!");
                }
                else if (sub == null)
                {
                    ModelState.AddModelError("sub", "Subject is not found!");
                }
                else if (model.Grade < 0 || model.Grade > 10)
                {
                    ModelState.AddModelError("gra", "Grade has to be from 0 - 10!");
                }
            }
            return View(model);
        }

        public IActionResult View (string pupilsName, string pupilsSurname)
        {

            var grade = GradeManager.Get(pupilsName, pupilsSurname).Select(g => g.ToModelG()).ToList();
            return View(grade);

        }

        public IActionResult View2(string subjectTitle)
        {

            var subjects = GradeManager.GetSub(subjectTitle).Select(g => g.ToModelG()).ToList();
            return View(subjects);

        }
        public IActionResult Average()
        {
            
            var pupils = PupilManager.GetAll().Select(s => s.ToModelP()).ToList();
            return View(pupils);

        }
    }

}



           