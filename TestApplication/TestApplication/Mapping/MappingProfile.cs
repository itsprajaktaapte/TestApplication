using AutoMapper;
using TestApplication.Models.Employee;
using TestApplication.ViewModels;

namespace TestApplication.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeViewModel>();
        }
    }
}
