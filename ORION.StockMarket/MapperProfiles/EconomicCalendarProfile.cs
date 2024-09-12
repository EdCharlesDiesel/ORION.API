using AutoMapper;
using ORION.StockMarket.DataAccess.Entities;
using ORION.StockMarket.DataAccess.Models;

namespace ORION.StockMarket.MapperProfiles
{
    public class EconomicCalendarProfile : Profile
    {
        public EconomicCalendarProfile()
        {
            CreateMap<Calendar, EconomicCalendarDto>();
            CreateMap<EconomicCalendarForCreationDto, Calendar>();

        }
    }
}
