using AutoMapper;
using ORION.StockMarket.DataAccess.Entities;
using ORION.StockMarket.DataAccess.Models;

namespace ORION.StockMarket.MapperProfiles
{
    public class EconomicCreditCardProfile : Profile
    {
        public EconomicCreditCardProfile()
        {
            CreateMap<CreditCard, EconomicCreditCardDto>();
            CreateMap<EconomicCreditCardForCreationDto, CreditCard>();

        }
    }
}
