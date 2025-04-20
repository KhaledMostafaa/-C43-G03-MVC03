using IKEA.DAL.Models.Departments;
using IKEA.DAL.Persistance.Reposatories.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Serivces.DepartmentService
{
    public class DepartmentServices:IdepartmentServices
    {
        private IDepartmentRepositor Repository;

        public DepartmentServices(IDepartmentRepositor _repositary)
        {
            Repository = _repositary;
        }
        

    }
}
