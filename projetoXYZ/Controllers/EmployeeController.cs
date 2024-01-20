using Microsoft.AspNetCore.Mvc;
using projetoXYZ.Context;
using projetoXYZ.Models;
using System.Web;

namespace projetoXYZ.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetData()
        {
            try
            {
                using (_context)
                {
                    List<Employee> empList = _context.Employees.ToList<Employee>();
                    return Json(new { data = empList, success = true });
                }
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message, success = false });
            }
        }

        [HttpGet]
        public IActionResult AddOrEdit(int id = 0)
        {
            return View(new Employee());
        }

        [HttpPost]
        public IActionResult AddOrEdit()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
