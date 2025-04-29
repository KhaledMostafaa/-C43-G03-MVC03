using IKEA.BLL.DTO.Departments;
using IKEA.BLL.Serivces.DepartmentService;
using IKEA.PL.ViewModels;
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
            ViewData["Message"] = "Hello From View Data";
          //  ViewBag.Message = "Hello From ViewBag";
            // ViewData  is a dictionary => key value pair


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
        public IActionResult Create(DepartmentVM departmentVM)
        {
            if (!ModelState.IsValid)
                return View(departmentVM);



            var Message = string.Empty;



            try
            {
                var departmentDTO = new CreatedDepartmentDTO()
                {
                    Name = departmentVM.Name,
                    Code = departmentVM.Code,
                    Description = departmentVM.Description,
                    CreationDate = DateOnly.FromDateTime(DateTime.Now)
                };
                var Result = departmentServices.CreateDepartment(departmentDTO);

                if (Result > 0)
                {
                    TempData["Message"] = $"{departmentDTO.Name} Department Created Successfully";
                    return RedirectToAction(nameof(Index));

                }

                else
                
                    Message = "Department is not Created ";
                   
                
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                if (webHost.IsDevelopment())
                
                    Message = ex.Message;
                
                
                else
                
                    Message = "An Error Effect at The Creation Operator";
                  
                


               
            }
            ModelState.AddModelError(string.Empty, Message);
            return (View(departmentVM));

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
            var MappedDepartment = new DepartmentVM()
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

        public IActionResult Edit(DepartmentVM departmentVM)
        {
            if(!ModelState.IsValid)
                return View(departmentVM);
           
            var message = string.Empty;
            try 
            {
                var departmentDTO = new UpdatedDepartmentDto()
                {
                    Id = departmentVM.Id,
                    Name = departmentVM.Name,
                    Code = departmentVM.Code,
                    Description = departmentVM.Description,
                    CreationDate = DateOnly.FromDateTime(DateTime.Now)
                };
                var result = departmentServices.UpdateDepartment(departmentDTO);
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
            return View(departmentVM);

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
