using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.DTO.Departments
{
    public class UpdatedDepartmentDto
    {
    
        public int Id { get; set; }

        [Required(ErrorMessage = "the name is required")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "the Code is required")]
        public string Code { get; set; } = null!;

        public string? Description { get; set; }
        [Display(Name="Date of creation")]

        public DateOnly CreationDate { get; set; }

    }
}
