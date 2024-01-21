using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetoXYZ.Context;
using projetoXYZ.Interfaces.IRepositories;
using projetoXYZ.Interfaces.IRepositories.IBaseRepository;
using projetoXYZ.Interfaces.IService;
using projetoXYZ.Models;
using System.Web;

namespace projetoXYZ.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetData()
        {
            try
            {
                IEnumerable<Employee> empList = await _service.GetAll();

                return Json(new { data = empList, success = true });
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
                Employee emp = await _service.GetById(id);
                if (emp != null)
                {
                    await _service.Delete(emp);
                }
                return Json(new { success = true, message = "Deleted Successfully!!" });

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
                return View(await _service.GetById(id));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrEdit(Employee employee)
        {
            try
            {
                if (!ModelState.IsValid) { return View(); }
                string message = string.Empty;
                if (employee.EmployeeID == 0)
                {
                    await _service.Add(employee);
                    message = "Saved Successfully!!";
                }
                else
                {
                    await _service.Update(employee);
                    message = "Updated Successfully!!";
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
