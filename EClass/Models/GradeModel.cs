using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EClass.Models
{
    public class GradeModel
    {
        [Required]
        [Display(Name = "Grade")]
        public int Grade { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(100)]
        [Display(Name = "Description")]
        public string Description { get; set; }
        
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string PupilsName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Surname")]
        public string PupilsSurname { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Subject")]
        public string SubjectTitle { get; set; }

    }
}
