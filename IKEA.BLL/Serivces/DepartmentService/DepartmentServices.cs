using IKEA.BLL.DTO.Departments;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.Persistance.Reposatories.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace IKEA.BLL.Serivces.DepartmentService
{
    public class DepartmentServices:IdepartmentServices
    {

        private IDepartmentRepositor Repository;


        public DepartmentServices(IDepartmentRepositor _repository)
        {
            Repository = _repository;
        }
        public IEnumerable<DepartmentToReturnDto> GetAllDepartment()  
        {
            var Departments = Repository.GetAll().Where(D=>!D.IsDeleted).Select(dept=>new DepartmentToReturnDto()
            {
                Id = dept.Id,
                Name = dept.Name,
                Code = dept.Code,
                CreationDate = dept.CreationDate,

            }).ToList();
            return Departments;
        }
        //    List<DepartmentToReturnDto>departmentToReturnDtos = new List<DepartmentToReturnDto>();
        //    foreach(var dept in Departments)

        //    {
        //        DepartmentToReturnDto departmentToReturnDto = new DepartmentToReturnDto()
        //        {
        //            Id= dept.Id,
        //            Name= dept.Name,
        //            Code= dept.Code,
        //            CreationDate= dept.CreationDate,
        //        };
        //        departmentToReturnDtos.Add(departmentToReturnDto);

        //    }
        //    return departmentToReturnDtos;

        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
           var Department = Repository.GetById(id);
            if (Department is not null)
                return new DepartmentDetailsDto()
                {
                    Id = Department.Id,
                    Name = Department.Name,
                    Code = Department.Code,
                    Description = Department.Description,
                    CreationDate = Department.CreationDate,
                    IsDeleted = Department.IsDeleted,
                    LastModifiedBy = Department.LastModifiedBy,
                    LastModifiedOn = Department.LastModifiedOn,
                    CreatedBy = Department.CreatedBy,
                    CreadedOn = Department.CreadedOn,

                };
            return null;
        }
        

        public int CreateDepartment(CreatedDepartmentDTO departmentDTO)
         {
            var CreatedDepartment =new Department()
            {
                Code = departmentDTO.Code,
                Name = departmentDTO.Name,
                Description = departmentDTO.Description,
                CreationDate= departmentDTO.CreationDate,
                CreatedBy=1,
                CreadedOn=DateTime.Now,
                LastModifiedOn =DateTime.Now,
                LastModifiedBy=1,
               
            };
            return Repository.Add(CreatedDepartment);
        }
         
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            var UpdatedDepartment = new Department()
            {
                Id = departmentDto.Id,
                Code = departmentDto.Code,
                Name = departmentDto.Name,
                Description = departmentDto.Description,
                CreationDate = departmentDto.CreationDate,
                LastModifiedBy = 1,
                CreadedOn = DateTime.Now,
            };
            return Repository.Update(UpdatedDepartment);
        }

        public bool DeleteDepartment(int id)  
        {
            var Department=Repository.GetById(id);
         
            if(Department is not null) 
             return Repository.Delete(Department)>0;

            else 
                return false;

             
            
          
        }
    }
}
