using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebEmployeeManagement.Models
{
    public class EmployeeModel
{
    public int Id { get; set; }

    [Required]
    [DataType(DataType.Text)]
    [StringLength(20)]
    [Display(Name = "Name: ")]
    public string Name { get; set; }

    [DataType(DataType.Text)]
    [StringLength(20)]
    [Display(Name = "Surname: ")]
    public string Surname { get; set; }

    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "Birthyear: ")]
    public int Year { get; set; }

    [DataType(DataType.Text)]
    [StringLength(100)]
    [Display(Name = "Position: ")]
    public string Position { get; set; }

    [DataType(DataType.Text)]
    [StringLength(100)]
    [Display(Name = "Division: ")]
    public string Division { get; set; }

}
}
