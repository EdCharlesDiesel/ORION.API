using AutoMapper;
using Microsoft.AspNetCore.Http.Features;

namespace ORION.HumanResources.MapperProfiles
{
    public class StatisticsProfile : Profile
    {
        public StatisticsProfile()
        {
            CreateMap<IHttpConnectionFeature, Models.StatisticsDto>();
        }
    }
}
