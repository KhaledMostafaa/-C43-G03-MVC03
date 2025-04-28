using IKEA.DAL.Models;
using IKEA.DAL.Models.Employees;
using IKEA.DAL.Persistance.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Persistance.Reposatories._Generic
{
    public class GenericReposaitory<T> : IGenericReposatiory<T> where T : ModelBase
    {

        private readonly ApplicationDbContext dbContext;
        public GenericReposaitory(ApplicationDbContext context)
        {
            dbContext = context;

        }

        public IQueryable<T> GetAll(bool WithNoTracking = true)
        {
            if (WithNoTracking)
                return dbContext.Set<T>().AsNoTracking();

            return dbContext.Set<T>();
        }


        public T? GetById(int id)
        {
            var item = dbContext.Set<T>().Find(id);
            //var Department = dbContext.Departments.Local.FirstOrDefault(D => D.Id == id);

            //if(Department == null)
            //    Department=dbContext.Departments.FirstOrDefault(D => D.Id == id);

            return item;
        }


        public int Add(T item)
        {
            dbContext.Set<T>().Add(item);
            return dbContext.SaveChanges();
        }
        public int Update(T item)
        {
            dbContext.Set<T>().Update(item);
            return dbContext.SaveChanges();
        }


        public int Delete(T item)
        {
            item.IsDeleted = true;
            dbContext.Set<T>().Update(item);

            return dbContext.SaveChanges();
        }

       
    }
}  
