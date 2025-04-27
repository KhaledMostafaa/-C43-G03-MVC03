using IKEA.BLL.DTO.Departments;
using IKEA.BLL.DTO.Employees;
using IKEA.BLL.Serivces.DepartmentService;
using IKEA.BLL.Serivces.EmployeeServices;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.PL.Controllers
{
    public class EmployeeController : Controller

    {
        private readonly IEmployeeServices employeeServices;
        private readonly ILogger<EmployeeController> logger;
        private readonly IWebHostEnvironment environment;

        public EmployeeController(IEmployeeServices employeeServices,ILogger<EmployeeController>logger,IWebHostEnvironment environment)
        {
            this.employeeServices = employeeServices;
            this.logger = logger;
            this.environment = environment;

        }

        #region Index
        [ HttpGet]
        public IActionResult Index()
        {
            var employees = employeeServices.GetAllEmployees();
            return View(employees);
        }
        #endregion
        
        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatedEmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
                return View(employeeDto);
            var Message = string.Empty;



            try
            {
                var Result =employeeServices.CreateEmployee(employeeDto);

                if (Result > 0)

                    return RedirectToAction(nameof(Index));
                else
                    Message = "Department is not Created ";
                   
                
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                if (environment.IsDevelopment())
                {
                    Message = ex.Message;
                   
                }
                else
                {
                    Message = "An Error Effect at The Creation Operator";
                    
                }
               


            }
            ModelState.AddModelError(string.Empty, Message);
            return (View(employeeDto));

        }
        #endregion


    }
}
