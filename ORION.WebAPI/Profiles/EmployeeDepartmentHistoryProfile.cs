using AutoMapper;

namespace ORION.WebAPI.Profiles
{
    public class EmployeeDepartmentHistoryProfile : Profile
    {
        public EmployeeDepartmentHistoryProfile()
        {
            CreateMap<Entities.EmployeeDepartmentHistory, Models.EmployeeDepartmentHistoryDto>();
            CreateMap<Models.ShiftForCreationDto, Entities.EmployeeDepartmentHistory>();
            CreateMap<Models.ShiftForUpdateDto, Entities.EmployeeDepartmentHistory>();
            CreateMap<Entities.EmployeeDepartmentHistory, Models.ShiftForUpdateDto>();
        }
    }
}
