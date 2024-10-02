using AutoMapper;
using ORION.Sales.DataAccess.Entities;
using ORION.Sales.DataAccess.Models;

namespace ORION.Sales.MapperProfiles
{
    public class CreditCardProfile : Profile
    {
        public CreditCardProfile()
        {
            CreateMap<CreditCard, CreditCardDto>();
        }
    }
}
