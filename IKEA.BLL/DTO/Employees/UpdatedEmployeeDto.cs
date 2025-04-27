using IKEA.DAL.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.DTO.Employees
{
    public class UpdatedEmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public int? Age { get; set; }

        public decimal Salary { get; set; }

        public bool IsActive { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly HiringDate { get; set; }

        public string? Email { get; set; }
        public Gender Gender { get; set; } 
        public EmployeeType EmployeeType { get; set; } 
    }
}
