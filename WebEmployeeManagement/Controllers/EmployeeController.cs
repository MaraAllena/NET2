using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebEmployeeManagement.DB;
using WebEmployeeManagement.Models;




namespace WebEmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        //public static List<EmployeeModel> Employees = new List<EmployeeModel>();
        public static List<string> div = new List<string>();

        public IActionResult Index()
        {
            using (var db = new Context())
            {
                var model = db.Employees.OrderBy(i => i.Division).ThenBy(i => i.Surname)
                .Select(i => new EmployeeModel()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Surname = i.Surname,
                    Year = i.Birthyear,
                    Position = i.Position,
                    Division = i.Division

                }).ToList();
                return View(model);
            }

            // var model = Employees
            //.OrderBy(i => i.Division).ThenBy(i => i.Surname)
            //.ToList();
        }

        public IActionResult Add()
        {

            var employee = new EmployeeModel();
            return View(employee);

        }

        [HttpPost]
        public IActionResult Add(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new Context())
                {
                    db.Employees.Add(new Employees()
                    {
                        Id = model.Id,
                        Name = model.Name,
                        Surname = model.Surname,
                        Birthyear = model.Year,
                        Position = model.Position,
                        Division = model.Division

                    });
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(model);
            //model.Id = Employees.Count + 1;
            //Employees.Add(model);
            //return RedirectToAction("Index");
        }
    } }

    /*public IActionResult Divisions(EmployeeModel model)
    {
        using (var db = new Context())
        {
            var division = db.Employees.FirstOrDefault(c => c.Division == model.Division);
            {
                db.Divisions.Add(new Divisions()
                {
                    Division = model.Division
                });
                db.SaveChanges();
            }.Distinct().ToList();

        }
        return View(model);*/
    //var div = Employees.Select(e => e.Division).Distinct().ToList();
    //.Select(e => e.Division)



