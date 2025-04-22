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

       


        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
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




    } 
}
