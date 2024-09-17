using AutoMapper;
using ORION.Sales.DataAccess.Entities;

namespace ORION.Sales.MapperProfiles
{
    public class SalesPersonProfile : Profile
    {
        public SalesPersonProfile()
        {
            CreateMap<SalesPerson, SalesPersonDto>();
        }
    }

    public class SalesPersonDto
    {
    }
}
