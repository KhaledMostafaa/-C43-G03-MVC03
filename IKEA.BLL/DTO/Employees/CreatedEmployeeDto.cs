using IKEA.DAL.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.DTO.Employees
{
    public class CreatedEmployeeDto
    {
        [MaxLength(50,ErrorMessage ="Max Length of Name is 50 chars")]
        [MinLength(5,ErrorMessage ="Min Length of Name is 5 chars")]

        public string Name { get; set; } = null!;
        [Range(22,30)]
        public int? Age { get; set; }

        public decimal Salary { get; set; }
        [Display(Name="is active")]
        public bool IsActive { get; set; }
        public string? PhoneNumber { get; set; }
        [Display(Name ="Hiring Date")]
        public DateOnly HiringDate { get; set; }
        [EmailAddress]

        public string? Email { get; set; }
        public Gender Gender { get; set; } 
        public EmployeeType EmployeeType { get; set; } 
    }
}
