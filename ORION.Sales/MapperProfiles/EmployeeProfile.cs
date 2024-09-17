using AutoMapper;

namespace ORION.Sales.MapperProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Calendar, Models.CalendarDto>();
        }
    }
}
