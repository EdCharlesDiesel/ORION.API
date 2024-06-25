using AutoMapper;

namespace ORION.WebAPI.Profiles
{
    public class ShiftProfile : Profile
    {
        public ShiftProfile()
        {
            CreateMap<Entities.Shift, Models.ShiftWithoutEmployeeDepartmentHistoryDto>();
            CreateMap<Entities.Shift, Models.ShiftDto>();
        }
    }
}
