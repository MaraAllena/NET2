using EClass.Controllers;
using EClass.Logic;
using EClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EClass.Extensions
{
   public static class MappingExtensions
    {
        public static GradeModel ToModelG (this Grades g)
        {
            return new GradeModel()
            {
                Grade = g.Grade,
                Description = g.Description,
                PupilsName = g.Name,
                PupilsSurname = g.Surname,
                SubjectTitle = g.Subject
            };
        }

        public static PupilModel ToModelP (this Pupils p)
        {
            {
                return new PupilModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Surname = p.Surname,
                    Birthyear = p.Birthyear,
                    ClassNumber = p.ClassNumber,
                    AverageGrade = Math.Round(GradeManager.Average(p.Name, p.Surname), 1)
                };
            }
        }

        public static SubjectModel ToModelS (this Subjects s)
        {
            {
                return new SubjectModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    
                };
            }
        }
    }
}
