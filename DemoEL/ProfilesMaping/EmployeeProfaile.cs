using AutoMapper;
using DemoDAL.Models;
using DemoEL.ViewsModels;

namespace DemoEL.ProfilesMaping
{
    public class EmployeeProfaile : Profile
    {
        public EmployeeProfaile()
        {
            CreateMap<Employee, EmployeeViewModelcs>().ReverseMap();
        }
        
    }
}
