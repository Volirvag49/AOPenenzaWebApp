using AOPenenzaTest.BLL.AbstractEmployeeService.DTO;
using AOPenenzaTest.DAL.EF.Entities;
using AutoMapper;

namespace WebApp.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DbEmployee, EmployeeDTO>();
            CreateMap<EmployeeDTO, DbEmployee>();
        }
    }
}