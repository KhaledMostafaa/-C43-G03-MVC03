using IKEA.DAL.Models.Departments;
using IKEA.DAL.Persistance.Data;
using IKEA.DAL.Persistance.Reposatories._Generic;
using IKEA.DAL.Persistance.Reposatories.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Models.Employees
{
    public class EmployeeReposatiory :GenericReposaitory<Employee>, IEmployeeReposatoiry
    {
        private readonly ApplicationDbContext dbContext;
        public EmployeeReposatiory(ApplicationDbContext context) : base(context)
        {
            dbContext = context;

        }






    }
}
