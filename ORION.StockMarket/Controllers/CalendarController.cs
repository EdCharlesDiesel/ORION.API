using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ORION.StockMarket.DataAccess.Entities;
using ORION.StockMarket.DataAccess.Models;
using ORION.StockMarket.DataAccess.Services;
using System.Net.Http;
using System.Xml.Serialization;

namespace ORION.StockMarket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalendarController : ControllerBase
    {
        private readonly ILogger<CalendarController> _logger;
        private readonly ICalendarRepository _calendarRepository;
        private readonly IMapper _mapper;
        private static HttpClient _httpClient;
        public CalendarController(ILogger<CalendarController> logger,
            ICalendarRepository calendarRepository,
                IMapper mapper, HttpClient __httpClient)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _calendarRepository = calendarRepository ?? throw new ArgumentNullException(nameof(calendarRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            //_httpClient.BaseAddress = new Uri("http://localhost:57863");
            _httpClient.Timeout = new TimeSpan(0, 0, 30);
            _httpClient.DefaultRequestHeaders.Clear();
        }
   

        [HttpOptions()]
        public IActionResult GetEconomicCalendarOptions()
        {
            Response.Headers.Add("Allow", "GET,HEAD,POST,OPTIONS");
            return Ok();
        }

        [HttpGet(Name = "GetEconomicCalenders")]

        public async Task<ActionResult<IEnumerable<EconomicCalendarDto>>> GetEconomicCalenders()
        {
            var economicCalendars = await _calendarRepository.GetCalendarsAsync();

            return Ok(_mapper.Map<IEnumerable<EconomicCalendarDto>>(economicCalendars));
        }


        //[HttpPost(Name = "CreateCalendar")]
        //public async Task<ActionResult<EconomicCalendarDto>> CreateCalendar(EconomicCalendarForCreationDto calendar)
        //{
        //    var calendarToSave = _mapper.Map<Calendar>(calendar);

        //    _calendarRepository.AddCalendar(calendarToSave);
        //    await _calendarRepository.SaveChangesAsync();

        //    var calendarToReturn = _mapper.Map<EconomicCalendarDto>(calendarToSave);
        //    return CreatedAtAction("GetEconomicCalenders",
        //        new
        //        {
        //            CalendarId = calendarToReturn.CalendarId
        //        },
        //        calendarToReturn);

        //}

        [HttpPost(Name = "CreateCalendars")]
        public async Task<ActionResult<IEnumerable<EconomicCalendarDto>>> CreateCalendars([FromBody] List<Calendar> calendars)
        {
            if (calendars == null || !calendars.Any())
            {
                return BadRequest("List of calendars cannot be empty.");
            }


            await _calendarRepository.AddCalendarsAsync(calendars);
            await _calendarRepository.SaveChangesAsync();
            return Ok("Calendars added successfully");
        }

        //[HttpPost]
        //public async Task<ActionResult<Calendar>> GetEcomomicCalendarFromAPI()
        //{
        //    var response = await _httpClient.GetAsync("https://api.tradingeconomics.com/calendar?c=e9f95eed6aa6465:blsksmd6c5y89rx");
        //    response.EnsureSuccessStatusCode();
        //    var content = await response.Content.ReadAsStringAsync();
        //    List<Calendar> calendars =
        //        //if (response.Content.Headers.ContentType.MediaType == "application/json")
        //        //{
        //        JsonConvert.DeserializeObject<List<Calendar>>(content);
        //    //}
        //    //else if (response.Content.Headers.ContentType.MediaType == "application/xml")
        //    //{
        //    var serializer = new XmlSerializer(typeof(List<Calendar>));
        //        calendars = (List<Calendar>)serializer.Deserialize(new StringReader(content));
        //    //}

        //    return Ok(calendars);
        //}



    }
}
