using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                using (_context)
                {
                    Employee? emp = _context.Employees.Where(x => x.EmployeeID == id).FirstOrDefault();
                    _context.Employees.Remove(emp);
                    _context.SaveChanges();

                    return Json(new { success = true, message = "Deleted Successfully!!" });
                }
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Not possible deleted the employee!!" });
            }
        }

        [HttpGet]
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Employee());
            }
            else
            {
                using (_context)
                {
                    return View(_context.Employees.Where(x => x.EmployeeID == id).FirstOrDefault<Employee>());
                }
            }
        }

        [HttpPost]
        public IActionResult AddOrEdit(Employee employee)
        {
            try
            {
                if (!ModelState.IsValid) { return View(); }
                string message = string.Empty;
                using (_context)
                {
                    if (employee.EmployeeID == 0)
                    {
                        _context.Employees.Add(employee);
                        message = "Saved Successfully!!";
                    }
                    else
                    {
                        _context.Entry(employee).State = EntityState.Modified;
                        message = "Updated Successfully!!";
                    }
                    _context.SaveChanges();
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
