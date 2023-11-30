using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TestApplication.Models;
using TestApplication.DataContext;
using TestApplication.ViewModels;
using TestApplication.Models.Employee;

namespace TestApplication.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly DatabaseDbContext _dc;
        private readonly IMapper _mapper;
        public EmployeeService(DatabaseDbContext context,IMapper mapper)
        {
            _dc = context;
            _mapper = mapper;
        }

        public async Task<List<EmployeeViewModel>> GetEmployees()
        {
            var emp = await _dc.Employees.ToListAsync();
            return _mapper.Map<List<EmployeeViewModel>>(emp);
        }

        public async Task<EmployeeViewModel> GetEmployee(int? id)
        {
            var emp = await _dc.Employees.FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<EmployeeViewModel>(emp);
        }

        public async Task<int> AddEmployee(AddEmployeeViewModel model)
        {
            var emp = new Employee
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
               
            };

            _dc.Employees.Add(emp);
            await _dc.SaveChangesAsync();

            return emp.Id;
        }

        public async Task<EmployeeViewModel> UpdateEmployee(UpdateEmployeeViewModel model)
        {

            var emp = await _dc.Employees.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (emp == null)
            {
                throw new ApplicationException();
            }

            emp.FirstName = model.FirstName;
            emp.LastName = model.LastName;


            _dc.Employees.Update(emp);
            await _dc.SaveChangesAsync();

            return _mapper.Map<EmployeeViewModel>(emp);
        }

        public async Task DeleteEmployee(int id)
        {
            var emp = new Employee { Id = id };

            _dc.Employees.Remove(emp);
            await _dc.SaveChangesAsync();
        }

       

       
    }
}
