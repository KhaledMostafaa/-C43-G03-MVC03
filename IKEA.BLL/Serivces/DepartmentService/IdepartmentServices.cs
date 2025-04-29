using IKEA.BLL.DTO.Departments;
using Microsoft.IdentityModel.Logging;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace IKEA.BLL.Serivces.DepartmentService
{
    public interface IdepartmentServices
    {//dto:data transfer object 
        IEnumerable<DepartmentToReturnDto> GetAllDepartment();
        DepartmentDetailsDto? GetDepartmentById(int id);
       

        int CreateDepartment(CreatedDepartmentDTO departmentDTO);
        int UpdateDepartment(UpdatedDepartmentDto departmentDto);

        bool DeleteDepartment(int id);
    }
}
