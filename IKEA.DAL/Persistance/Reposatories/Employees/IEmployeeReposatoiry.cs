using IKEA.DAL.Models.Departments;
using IKEA.DAL.Models.Employees;
using IKEA.DAL.Persistance.Reposatories._Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace IKEA.DAL.Persistance.Reposatories.Employees
{
    public interface IEmployeeReposatoiry:IGenericReposatiory<Employee>
    {
        

    }
}
