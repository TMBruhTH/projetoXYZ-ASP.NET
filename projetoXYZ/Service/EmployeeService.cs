using projetoXYZ.Interfaces.IRepositories.IBaseRepository;
using projetoXYZ.Interfaces.IService;
using projetoXYZ.Models;

namespace projetoXYZ.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IBaseRepository<Employee> _employeeService;

        public EmployeeService(IBaseRepository<Employee> employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task Add(Employee entity)
        {
            await _employeeService.Add(entity);
        }

        public async Task Delete(Employee entity)
        {
            await _employeeService.Delete(entity);
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _employeeService.GetAll();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _employeeService.GetById(id);
        }

        public async Task Update(Employee entity)
        {
            await _employeeService.Update(entity);
        }
    }
}
