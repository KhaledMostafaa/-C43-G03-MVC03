using IKEA.BLL.Serivces.DepartmentService;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private IdepartmentServices departmentServices;
        public DepartmentController(IdepartmentServices _departmentServices)
        {
          departmentServices = _departmentServices;

        }
        #region Index
        public IActionResult Index()
        {
            var Departments = departmentServices.GetAllDepartment();

            return View(Departments);

        } 
        #endregion
    }
}
