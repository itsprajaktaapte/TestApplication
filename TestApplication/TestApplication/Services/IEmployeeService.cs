
using TestApplication.ViewModels;
namespace TestApplication.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeViewModel>> GetEmployees();

        Task<EmployeeViewModel> GetEmployee(int? id);

        Task<int> AddEmployee(AddEmployeeViewModel model);

        Task<EmployeeViewModel> UpdateEmployee(UpdateEmployeeViewModel model);

        Task DeleteEmployee(int Id);
    }
}
