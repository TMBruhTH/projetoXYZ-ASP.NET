using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetoXYZ.Context;
using projetoXYZ.Interfaces.IRepositories.IBaseRepository;
using projetoXYZ.Models;
using System.Web;

namespace projetoXYZ.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IBaseRepository<Employee> _employeeRepository;

        public EmployeeController(AppDbContext context, IBaseRepository<Employee> employeeRepository)
        {
            _context = context;
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetData()
        {
            try
            {
                using (_context)
                {
                    IEnumerable<Employee> empList = await _employeeRepository.GetAll();
                    return Json(new { data = empList, success = true });
                }
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message, success = false });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                using (_context)
                {
                    Employee emp = await _employeeRepository.GetById(id);
                    if (emp != null)
                    {
                        await _employeeRepository.Delete(emp);
                    }
                    return Json(new { success = true, message = "Deleted Successfully!!" });
                }
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Not possible deleted the employee!!" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Employee());
            }
            else
            {
                using (_context)
                {
                    return View(await _employeeRepository.GetById(id));
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrEdit(Employee employee)
        {
            try
            {
                if (!ModelState.IsValid) { return View(); }
                string message = string.Empty;
                using (_context)
                {
                    if (employee.EmployeeID == 0)
                    {
                        await _employeeRepository.Add(employee);
                        message = "Saved Successfully!!";
                    }
                    else
                    {
                        await _employeeRepository.Update(employee);
                        message = "Updated Successfully!!";
                    }
                }
                return Json(new { success = true, message });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
