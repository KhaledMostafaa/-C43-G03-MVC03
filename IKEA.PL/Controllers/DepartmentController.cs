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
        public IActionResult Index()
        {

            return View();
        }
    }
}
