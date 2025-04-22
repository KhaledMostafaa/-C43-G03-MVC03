using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.DTO.Departments
{
    public class DepartmentDetailsDto
    {
        public int Id { get; set; }
        #region Adminstrator


        public bool IsDeleted { get; set; } //soft Delete

        public int CreatedBy { get; set; }

        public DateTime CreadedOn { get; set; }

        public int LastModifiedBy { get; set; }

        public DateTime LastModifiedOn { get; set; }
        #endregion

      
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;

        public string? Description { get; set; }

        public DateOnly CreationDate { get; set; }

        

    }
}
