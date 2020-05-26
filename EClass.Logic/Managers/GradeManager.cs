using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EClass.Logic
{
    public class GradeManager
    {
        public static List<Grades> GetAll()
        {
            using (var db = new DbContext())
            {

                return db.Grades.OrderByDescending(x => x.Grade).ToList();
            }
        }

        public static Subjects FindSub(string SubjectTitle)
        {
            using (var db = new DbContext())
            {
                return db.Subjects.FirstOrDefault(c => c.Name == SubjectTitle);
            }
        }
        public static Pupils FindName(string PupilsName)
        {
            using (var db = new DbContext())
            {
                return db.Pupils.FirstOrDefault(c => c.Name == PupilsName);
            }
        }
        public static Pupils FindSurname(string PupilsSurname)
        {
            using (var db = new DbContext())
            {
                return db.Pupils.FirstOrDefault(c => c.Surname == PupilsSurname);
            }
        }
        public static void Create(int grade, string description, string name, string surname, string subject)
        {
            using (var db = new DbContext())
            {
                db.Grades.Add(new Grades()
                {
                    Grade = grade,
                    Description = description,
                    Name = name,
                    Surname = surname,
                    Subject = subject
                });

                db.SaveChanges();
            }
        }

        public static List<Grades> Get(string pupilsName, string pupilsSurname)
        {
            using (var db = new DbContext())
            {
                return db.Grades.Where(g => g.Name == pupilsName && g.Surname == pupilsSurname).ToList();
            }
        }
        public static List<Grades> GetSub(string SubjectTitle)
        {
            using (var db = new DbContext())
            {
                return db.Grades.Where(g => g.Subject == SubjectTitle).ToList();
            }
        }

        public static double Average(string pupilsName, string pupilsSurname)
        {
            using (var db = new DbContext())
            {
                var grades = db.Grades.Where(s => s.Name == pupilsName && s.Surname == pupilsSurname).ToList();
                if (grades.Count == 0)
                {
                    return 0;
                }
                else
                {
                    return grades.Select(s => s.Grade).Average();
                }  

            }
        }

    }   
}
