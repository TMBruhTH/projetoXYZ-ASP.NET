using projetoXYZ.Models;
using projetoXYZ.ViewModel;

namespace projetoXYZ.Interfaces.IService
{
    public interface IEmployeeService
    {
        Task<EmployeeViewModel> GetById(int id);
        Task<IEnumerable<EmployeeViewModel>> GetAll();
        Task Add(EmployeeViewModel entity);
        Task Update(EmployeeViewModel entity);
        Task Delete(EmployeeViewModel entity);
    }
}
