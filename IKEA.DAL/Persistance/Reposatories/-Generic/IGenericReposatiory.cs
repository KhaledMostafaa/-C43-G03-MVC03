using IKEA.DAL.Models;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Persistance.Reposatories._Generic
{
    public interface IGenericReposatiory<T>where T:ModelBase
    {
        IQueryable<T> GetAll(bool WithNoTracking = true);

        T GetById(int id);

        int Add(T Item);
        int Delete(T Item);
        int Update(T Item);

      
    }
}
