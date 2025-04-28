using IKEA.BLL.DTO.Departments;
using IKEA.BLL.Serivces.DepartmentService;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IKEA.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IdepartmentServices departmentServices;
        private readonly ILogger<DepartmentController> logger;
        private readonly IWebHostEnvironment webHost;

        public DepartmentController(IdepartmentServices _departmentServices,ILogger<DepartmentController>_logger,IWebHostEnvironment webHost)
        {
          departmentServices = _departmentServices;
            logger = _logger;
            this.webHost = webHost;
        }
        
        #region Index
        [HttpGet]
        public IActionResult Index()
        {
            var Departments = departmentServices.GetAllDepartment();

            return View(Departments);

        }
        #endregion


        #region Details
        [HttpGet]
        public IActionResult Details(int? id)
        {

            if (id is null)
                return BadRequest();
            var department = departmentServices.GetDepartmentById(id.Value);
            if (department is null)
                return NotFound();
            return View(department);
        }
        #endregion


        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatedDepartmentDTO departmentDTO)
        {
            if (!ModelState.IsValid)
                return View(departmentDTO);



            var Message = string.Empty;



            try
            {
                var Result = departmentServices.CreateDepartment(departmentDTO);

                if (Result > 0)

                    return RedirectToAction(nameof(Index));
                else
                {
                    Message = "Department is not Created ";
                    ModelState.AddModelError(string.Empty, Message);
                    return View(departmentDTO);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                if (webHost.IsDevelopment())
                {
                    Message = ex.Message;
                    ModelState.AddModelError(string.Empty, Message);
                    return (View(departmentDTO));
                }
                else
                {
                    Message = "An Error Effect at The Creation Operator";
                    ModelState.AddModelError(string.Empty, Message);
                    return (View(departmentDTO));
                }


            }

        }
        #endregion

        #region update
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id is null)
                return BadRequest();
            var department = departmentServices.GetDepartmentById(id.Value);
            if (department is null)
                return NotFound();
            var MappedDepartment = new UpdatedDepartmentDto()
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                CreationDate = department.CreationDate
            };
            return View(MappedDepartment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(UpdatedDepartmentDto departmentDto)
        {
            if(!ModelState.IsValid)
                return View(departmentDto);
           
            var message = string.Empty;
            try 
            {
                var result = departmentServices.UpdateDepartment(departmentDto);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    message = "Department is not Updated";  
                   
                }
                
            }
            catch (Exception ex)
            {
                logger.LogError(ex,ex.Message);
                message=webHost.IsDevelopment() ? ex.Message : "An Error Effect at The Update Operator";
                throw;
            }
            ModelState.AddModelError(string.Empty, message);
            return View(departmentDto);

        }




        #endregion

        #region Delete
        [HttpGet]    
        public IActionResult Delete(int?id)
        {
            if (id is null)
                return BadRequest();
            var department = departmentServices.GetDepartmentById(id.Value);
            if (department is null)
                return NotFound();
            return View(department);
        }
        #endregion

        [HttpPost]
        public IActionResult Delete(int Deptid)
        {
            var message = string.Empty;
            try
            {
               var IsDeleted= departmentServices.DeleteDepartment(Deptid);
                if (IsDeleted)
                    return RedirectToAction(nameof(Index));
                else
                {
                    message = "Department is not Deleted";
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                message = webHost.IsDevelopment() ? ex.Message : "An Error Effect at The Delete Operator";
                throw;
            }
            ModelState.AddModelError(string.Empty, message);
            return RedirectToAction(nameof(Delete), new {id=Deptid});
        }






    }
}
