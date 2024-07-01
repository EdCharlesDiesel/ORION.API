using AutoMapper;
using ORION.HumanResources.DataAccess.Entities;

namespace ORION.HumanResources.MapperProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        { 
            CreateMap<InternalEmployee, Models.InternalEmployeeDto>(); 
        }
    }
}
