using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EClass.Models
{
    public class PupilModel
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Surname")]
        public string Surname { get; set; }
        
        [DataType(DataType.Text)]
        [StringLength(4)]
        [Display(Name = "Birthyear")]
        public string Birthyear { get; set; }

        [Required]
        [Display(Name = "Class")]
        public int ClassNumber { get; set; }

        public double AverageGrade { get; set; }

    }
}
