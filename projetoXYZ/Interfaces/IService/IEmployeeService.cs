using projetoXYZ.Models;

namespace projetoXYZ.Interfaces.IService
{
    public interface IEmployeeService
    {
        Task<Employee> GetById(int id);
        Task<IEnumerable<Employee>> GetAll();
        Task Add(Employee entity);
        Task Update(Employee entity);
        Task Delete(Employee entity);
    }
}
