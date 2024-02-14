using projetoXYZ.Interfaces.IRepositories.IBaseRepository;
using projetoXYZ.Interfaces.IService;
using projetoXYZ.Models;
using projetoXYZ.ViewModel;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace projetoXYZ.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IBaseRepository<Employee> _employeeService;

        public EmployeeService(IBaseRepository<Employee> employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task Add(EmployeeViewModel entity)
        {
            var model = GetObj(entity);

            await _employeeService.Add(model);
        }

        public async Task Delete(int EmployeeID)
        {
            var model = await _employeeService.GetById(EmployeeID);

            await _employeeService.Delete(model);
        }

        public async Task<IEnumerable<EmployeeViewModel>> GetAll()
        {
            var retorno = await _employeeService.GetAll();
            var lsEmployeeViewModel = new List<EmployeeViewModel>();

            foreach (var item in retorno)
            {
                var obj = GetObjView(item);
                lsEmployeeViewModel.Add(obj);
            }

            IEnumerable<EmployeeViewModel> lsA = lsEmployeeViewModel;

            return lsA;
        }

        public async Task<EmployeeViewModel> GetById(int id)
        {
            var retorno = await _employeeService.GetById(id);

            return GetObjView(retorno);
        }

        public async Task Update(EmployeeViewModel entity)
        {
            var model = GetObj(entity);

            await _employeeService.Update(model);
        }

        private Employee GetObj(EmployeeViewModel model)
        {
            return new Employee
            {
                EmployeeID = model.EmployeeID,
                Name = model.Name,
                Position = model.Position,
                Office = model.Office,
                Age = model.Age,
                Salary = model.Salary
            };
        }

        private EmployeeViewModel GetObjView(Employee model)
        {
            return new EmployeeViewModel
            {
                EmployeeID = model.EmployeeID,
                Name = model.Name,
                Position = model.Position,
                Office = model.Office,
                Age = model.Age,
                Salary = model.Salary
            };
        }
    }
}
