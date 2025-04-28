using IKEA.BLL.DTO.Departments;
using IKEA.BLL.DTO.Employees;
using IKEA.BLL.Serivces.DepartmentService;
using IKEA.BLL.Serivces.EmployeeServices;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
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
        [ValidateAntiForgeryToken]

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

        #region Details
        [HttpGet]
        public IActionResult Details(int? id)
        {

            if (id is null)
                return BadRequest();
            var employee = employeeServices.GetEmployeeById(id.Value);
            if (employee is null)
                return NotFound();
            return View(employee);
        }
        #endregion

        #region Update
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
                return BadRequest();
            var Employee = employeeServices.GetEmployeeById(id.Value);
            if (Employee is null)
                return NotFound();
            var MappedEmployee = new UpdatedEmployeeDto()
            {
                Id = Employee.Id,
                Name = Employee.Name,
                Age = Employee.Age,
                Salary = Employee.Salary,
                HiringDate = Employee.HiringDate,
                Gender = Employee.Gender,
                EmployeeType = Employee.EmployeeType,
                IsActive = Employee.IsActive,
                PhoneNumber = Employee.PhoneNumber,


                Email = Employee.Email,

            };
            return View(MappedEmployee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UpdatedEmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
                return View(employeeDto);

            var message = string.Empty;
            try
            {
                var result = employeeServices.UpdatedEmployee(employeeDto);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    message = "Employee is not Updated";

                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                message = environment.IsDevelopment() ? ex.Message : "An Error Effect at The Update edmployee";
                throw;
            }
            ModelState.AddModelError(string.Empty, message);
            return View(employeeDto);

        }
        #endregion

        #region Delete
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();
            var Employee = employeeServices.GetEmployeeById(id.Value);
            if (Employee is null)
                return NotFound();
            return View(Employee);

        }
        
        [HttpPost]
        public IActionResult Delete(int EmpId)
        {
            var message = string.Empty;
            try
            {
                var IsDeleted = employeeServices.DeleteEmployee(EmpId);
                if (IsDeleted)
                    return RedirectToAction(nameof(Index));
                else
                {
                    message = "Employee is not Deleted";
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                message = environment.IsDevelopment() ? ex.Message : "An Error Effect at The Delete Employee";
                throw;
            }
            ModelState.AddModelError(string.Empty, message);
            return RedirectToAction(nameof(Delete), new { id = EmpId });

        }
        #endregion




    }
}
