using AutoMapper;
using ORION.HumanResources.ActionFilters;
using ORION.HumanResources.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace ORION.HumanResources.Controllers
{
    [Route("api/statistics")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMapper _mapper;
        public StatisticsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [CheckShowStatisticsHeader]
        public ActionResult<StatisticsDto> GetStatistics()
        {
            var httpConnectionFeature = HttpContext.Features
                .Get<IHttpConnectionFeature>();
            return Ok(_mapper.Map<StatisticsDto>(httpConnectionFeature));
        }
    }
}
