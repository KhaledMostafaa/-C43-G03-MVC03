using IKEA.BLL.DTO.Employees;
using IKEA.DAL.Models.Employees;
using IKEA.DAL.Persistance.Reposatories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Serivces.EmployeeServices
{
    public class EmployeeService:IEmployeeServices
    {
        private readonly IEmployeeReposatoiry reposatoiry;
        public EmployeeService(IEmployeeReposatoiry employeeReposatoiry)
        {
            reposatoiry = employeeReposatoiry;

        }

        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            var Employees = reposatoiry.GetAll();
            var FilteredEmployees = Employees
                .Where(E => E.IsDeleted == false);
                var AfterFilteration=FilteredEmployees.Select(E=>new EmployeeDto() 
            {
                Id = E.Id,
                Name = E.Name,
                Age = E.Age,
                
                Salary = E.Salary,
                IsActive = E.IsActive,
                Email = E.Email,
                Gender=E.Gender,
                EmployeeType = E.EmployeeType


            });
            return AfterFilteration.ToList();
        }

        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = reposatoiry.GetById(id);
            if(employee is not null)
            {
                return new EmployeeDetailsDto()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Age = employee.Age,
                    Address = employee.Address,
                    Salary = employee.Salary,
                    IsActive = employee.IsActive,
                    Email = employee.Email,
                    PhoneNumber = employee.PhoneNumber,
                    HiringDate = employee.HiringDate,
                    Gender = employee.Gender,
                    EmployeeType = employee.EmployeeType,
                    LastModifiedBy = employee.LastModifiedBy,
                    LastModifiedOn = employee.LastModifiedOn,
                    CreadedOn = employee.CreadedOn,
                    CreatedBy = employee.CreatedBy,


                };
               
            }
            return null;
                
        }

        public int CreateEmployee(CreatedEmployeeDto employeeDto)
        {
            var Employee = new Employee()
            {
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Salary = employeeDto.Salary,
                IsActive = employeeDto.IsActive,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.PhoneNumber,
                HiringDate = employeeDto.HiringDate,
                Gender = employeeDto.Gender,
                EmployeeType = employeeDto.EmployeeType,
                CreatedBy = 1,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.Now,
                CreadedOn = DateTime.Now,
            };
            return reposatoiry.Add(Employee);
        }
        public int UpdatedEmployee(UpdatedEmployeeDto employeeDto)
        {
            var Employee = new Employee()
            {
                Id = employeeDto.Id,
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Salary = employeeDto.Salary,
                IsActive = employeeDto.IsActive,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.PhoneNumber,
                HiringDate = employeeDto.HiringDate,
                Gender = employeeDto.Gender,
                EmployeeType = employeeDto.EmployeeType,
                CreatedBy = 1,
                LastModifiedOn = DateTime.Now,
               
            };
            return reposatoiry.Update(Employee);
        }

        public bool DeleteEmployee(int id)
        {
            var Employee = reposatoiry.GetById(id);

            if (Employee is not null)
                return reposatoiry.Delete(Employee) > 0;

            else
                return false;

        }

        

      

       
    }
}
