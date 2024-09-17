using AutoMapper;
using ORION.StockMarket.DataAccess.Entities;
using ORION.StockMarket.DataAccess.Models;

namespace ORION.StockMarket.MapperProfiles
{
    public class EconomicSalesPersonProfile : Profile
    {
        public EconomicSalesPersonProfile()
        {
            CreateMap<SalesPerson, EconomicSalesPersonDto>();
            CreateMap<EconomicSalesPersonForCreationDto, SalesPerson>();

        }
    }
}
