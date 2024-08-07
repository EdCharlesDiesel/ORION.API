using AutoMapper;
using ORION.HumanResources.ActionFilters;
using ORION.HumanResources.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Web.Http;

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

        [HttpGet(Name="Name")]
        public async ActionResult<IHttpActionResult> GetTradeByCountry()
        {
            Object myrespones = null;

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new
                    HttpMethod("GET"), "https://api.tradingeconomics.com/forecast/country/mexico?c=guest:guest"))
                {
                    request.Headers.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");
                    var response = await httpClient.SendAsync(request);
                    myrespones = response  ;
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(content);

                        return response;
                    }
                }                
            }            

            return Ok(myrespones);
        }
        //public async IHttpActionResult GetTradeByCountry()
        //{
        //    IList<Object> myrespones = null;
        //    using (var httpClient = new HttpClient())
        //    {
        //        using (var request = new HttpRequestMessage(new
        //            HttpMethod("GET"), "https://api.tradingeconomics.com/forecast/country/mexico?c=guest:guest"))
        //        {
        //            request.Headers.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");
        //            var response = await httpClient.SendAsync(request);
        //            response = myrespones;
        //            if (response.IsSuccessStatusCode)
        //            {
        //                var content = await response.Content.ReadAsStringAsync();
        //                Console.WriteLine(content);

        //                return response;
        //            }
        //        }

        //        return Ok(myrespones);
        //    }
        //}
    }

    public class Response
    {
        public int MyProperty { get; set; }
    }
}
