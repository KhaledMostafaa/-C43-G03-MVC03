using IKEA.DAL.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Persistance.Reposatories.Departments
{//getall getById Add Update Delete
    public interface IDepartmentRepositor
    {
        IEnumerable<Department> GetAll(bool WithNoTracking=true);

        Department GetById(int id);

        int Add(Department department);
        int Delete(Department department);
        int Update(Department department);



    }
}
